namespace Assignment.Graphics
{
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class FpsCounter : IGameComponent
    {
        public float CurrentFps { get; private set; }
        public float AverageFps { get; private set; }

        private int buffer_size;
        private Queue<float> buffer;

        public FpsCounter()
        {
            buffer = new Queue<float>();
        }

        public void Initialize()
        {
            buffer_size = MainGame.Config.Get<int>("FpsBufferLength");
        }

        public void Update(float deltaTime)
        {
            if (deltaTime <= 0) return;
            buffer.Enqueue(CurrentFps = 1 / deltaTime);
            if (buffer.Count > buffer_size) buffer.Dequeue();
            AverageFps = buffer.Average();
        }
    }
}