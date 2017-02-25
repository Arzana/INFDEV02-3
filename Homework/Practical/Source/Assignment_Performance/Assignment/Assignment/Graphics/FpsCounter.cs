namespace Assignment.Graphics
{
    using Mentula.GuiItems.Core;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;

    public sealed class FpsCounter : DrawableMentulaGameComponent<MainGame>
    {
        public float CurFps { get; private set; }
        public float AvrgFps { get; private set; }

        private Queue<float> buffer;
        private int buffLen;

        public FpsCounter(MainGame game)
            : base(game)
        {
            DrawOrder = 0;
            buffer = new Queue<float>();
            game.Components.Add(this);
        }

        public override void Initialize()
        {
            buffLen = MainGame.Config.Get<int>("FpsBufferLength");
            base.Initialize();
        }

        protected override void Dispose(bool disposing)
        {
            Game.Components.Remove(this);
            base.Dispose(disposing);
        }

        public override void Draw(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (delta <= 0) return;

            buffer.Enqueue(CurFps = 1.0f / delta);
            if (buffer.Count > buffLen) buffer.Dequeue();

            AvrgFps = buffer.Average();

            base.Draw(gameTime);
        }
    }
}