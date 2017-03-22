namespace Assignment.Graphics
{
    using Logic;
    using Mentula.GuiItems;
    using Mentula.GuiItems.Core;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Runtime.CompilerServices;
    using static MainGame;

    public sealed class SpriteRenderer : DrawableMentulaGameComponent<MainGame>
    {
        public float Scale { get; private set; }

        private int DisplayHeight { get { return graphics.GraphicsDevice.DisplayMode.Height; } }
        private int DisplayWidth { get { return graphics.GraphicsDevice.DisplayMode.Width; } }

        private const float DEG2RAD = 0.017453f;
        private float rot;

        private GraphicsDeviceManager graphics;
        private TextureCollection textures;
        private SpriteBatch batch;

        public SpriteRenderer(MainGame game)
            : base(game)
        {
            DrawOrder = 0;
            graphics = new GraphicsDeviceManager(game);
            game.Components.Add(this);
        }

        public override void Initialize()
        {
            Program.LogAgmnt("SpriteRenderer", "initializing renderer", "Gphx");
            InitSettings();

            batch = new SpriteBatch(graphics.GraphicsDevice);
            textures = TextureCollection.FromConfig(Game.Content, graphics.GraphicsDevice, "Textures");

            base.Initialize();
        }

        protected override void Dispose(bool disposing)
        {
            Program.LogAgmnt("SpriteRenderer", "disposing renderer", "Disp");
            textures.Dispose();
            batch.Dispose();
            Game.Components.Remove(this);
            base.Dispose(disposing);
        }

        public void BeginDraw()
        {
            graphics.GraphicsDevice.Clear(Color.LimeGreen);
            batch.Begin();
        }

        public override void Draw(GameTime gameTime)
        {
            DrawBatch(textures[0], Vector2.Zero, Vector2.One);
        }

        public void EndDraw()
        {
            batch.End();
        }

        private void InitSettings()
        {
            Program.LogAgmnt("SpriteRenderer", "initializing settings", "Gphx");
            graphics.PreferredBackBufferHeight = Config.Get<int>("ResolutionHeight");
            graphics.PreferredBackBufferWidth = Config.Get<int>("ResolutionWidth");

            if (Config.Get<bool>("SafeGraphics"))
            {
                if (graphics.PreferredBackBufferHeight > DisplayHeight) graphics.PreferredBackBufferHeight = DisplayHeight;
                if (graphics.PreferredBackBufferWidth > DisplayWidth) graphics.PreferredBackBufferWidth = DisplayWidth;
            }

            if (Config.Get<bool>("AutoScale")) Scale = graphics.PreferredBackBufferWidth / 800f;
            else Scale = Config.Get<float>("DefaultScale");
            rot = Config.Get<float>("DefaultRotation") * DEG2RAD;

            if (!Config.Get<bool>("Vsync"))
            {
                graphics.SynchronizeWithVerticalRetrace = false;
                Game.IsFixedTimeStep = false;
            }

            graphics.IsFullScreen = Config.Get<bool>("Fullscreen");
            if (Config.Get<bool>("Borderless")) Utilities.ChangeWindowBorder(Game, 0);
            else Utilities.ChangeWindowBorder(Game, 4);

            graphics.ApplyChanges();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawBatch(ISprite sprite) => DrawBatch(textures[sprite.Id], sprite.Position, sprite.Scale);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void DrawBatch(Rectangle source, Vector2 pos, Vector2 scale)
        {
            batch.Draw(textures.Sheet, pos, source, Color.White, rot, Vector2.Zero, scale * Scale, SpriteEffects.None, 0);
        }
    }
}