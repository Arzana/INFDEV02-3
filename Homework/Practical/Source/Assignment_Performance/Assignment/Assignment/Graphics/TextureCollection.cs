namespace Assignment.Graphics
{
    using Mentula.BasicContent;
    using Mentula.BasicContent.R;
    using Mentula.GuiItems.Core;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TextureCollection : Dictionary<int, Rectangle>, IDisposable
    {
        public Texture2D Sheet { get; private set; }

        private ContentManager content;
        private GraphicsDevice device;
        private Size size, max;

        new public Rectangle this[int key]
        {
            get
            {
                if (!ContainsKey(key)) throw new KeyNotFoundException($"Cannot find texture with ID: {key}!");
                return base[key];
            }
        }

        public TextureCollection(ContentManager content, GraphicsDevice device)
        {
            this.content = content;
            this.device = device;
        }

        public static TextureCollection FromConfig(ContentManager content, GraphicsDevice device, string name)
        {
            TextureCollection result = new TextureCollection(content, device);
            result.LoadFromConfig(name);
            return result;
        }

        public void LoadFromConfig(string name)
        {
            max = new Size(MainGame.Config.Get<int>("MaxTextureWidth"), MainGame.Config.Get<int>("MaxtextureHeight"));

            Dictionary<int, Texture2D> textures = new Dictionary<int, Texture2D>();
            R config = content.Load<R>(name);

            for (int i = 0; i < config.Values.Count; i++)
            {
                Add(textures, config.ElementAt(i));
            }

            SetupSheet(textures);
        }

        public void Add(Dictionary<int, Texture2D> coll, KeyValuePair<int, string> elmnt)
        {
            Texture2D text = content.Load<Texture2D>(elmnt.Value);
            CheckDims(text, elmnt);

            coll.Add(elmnt.Key, text);
            if (text.Height > size.Height) size.Height = text.Height;
            size.Width += text.Width;
        }

        public void Dispose()
        {
            Sheet.Dispose();
            Clear();
        }

        private void SetupSheet(Dictionary<int, Texture2D> textures)
        {
            using (RenderTarget2D target = new RenderTarget2D(device, size.Width, size.Height))
            {
                SpriteBatch sb = new SpriteBatch(device);

                device.SetRenderTarget(target);
                device.Clear(Color.Transparent);

                int x = 0;

                sb.Begin();
                foreach (KeyValuePair<int, Texture2D> tile in textures)
                {
                    sb.Draw(tile.Value, new Vector2(x, 0), Color.White);
                    Add(tile.Key, new Rectangle(x, 0, tile.Value.Width, tile.Value.Height));
                    x += tile.Value.Width;
                }
                sb.End();

                device.SetRenderTarget(null);
                Sheet = CopyColorData(target);
            }
        }

        private Texture2D CopyColorData(Texture2D source)
        {
            Texture2D text = new Texture2D(device, source.Width, source.Height);
            text.SetData(GetColorData(source));
            return text;
        }

        private Color[] GetColorData(Texture2D text)
        {
            Color[] result = new Color[text.Width * text.Height];
            text.GetData(result);
            return result;
        }

        private void CheckDims(Texture2D text, KeyValuePair<int, string> elmnt)
        {
            BuildException inner = null;

            if (text.Width > max.Width) inner = new BuildException($"Width is {text.Width}, max width = {max.Width}!");
            if (text.Height > max.Height)
            {
                string msg = $"Height is {text.Height}, max height = {max.Height}!";
                if (inner != null) msg += ", " + inner.Message;
                inner = new BuildException(msg);
            }
            if (inner != null) throw new BuildException($"Texture {elmnt.Value}({elmnt.Key}) is to large.", inner);
        }
    }
}