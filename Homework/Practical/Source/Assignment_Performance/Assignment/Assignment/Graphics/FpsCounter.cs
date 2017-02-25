namespace Assignment.Graphics
{
    using Mentula.GuiItems.Core;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;

    public sealed class FpsCounter : DrawableMentulaGameComponent<MainGame>
    {
        public float CurFps { get { return buffer.Peek(); } }
        public float AvrgFps { get { return buffer.Average(); } }

        private Queue<float> buffer;
        private int buffLen;

        public FpsCounter(MainGame game)
            :base(game)
        {
            DrawOrder = 0;
            buffer = new Queue<float>(new float[] { 0 });
        }

        public override void Initialize()
        {
            buffLen = MainGame.Config.Get<int>("FpsBufferLength");
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (delta <= 0) return;

            buffer.Enqueue(1.0f / delta);
            if (buffer.Count > buffLen) buffer.Dequeue();

            base.Draw(gameTime);
        }
    }
}