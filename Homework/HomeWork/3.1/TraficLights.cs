namespace _3._1
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public sealed class Timer
    {
        private DateTime? start;
        private TimeSpan delta;

        private List<Action> onTargetReached;
        private bool reached;

        public Timer(TimeSpan waitTime)
        {
            start = null;
            delta = waitTime;
            onTargetReached = new List<Action>();
            reached = false;
        }

        public void AddEvent(Action evnt)
        {
            onTargetReached.Add(evnt);
        }

        public void Start()
        {
            start = DateTime.UtcNow;
        }

        public bool Tick()
        {
            if (!reached)
            {
                if (start == null) throw new InvalidOperationException("Start must be called before calling tick!");
                if ((start.Value + delta) <= DateTime.UtcNow)
                {
                    InvokeEvents();
                    return true;
                }
            }

            return false;
        }

        public void Reset()
        {
            start = null;
            reached = false;
        }

        private void InvokeEvents()
        {
            reached = true;

            for (int i = 0; i < onTargetReached.Count; i++)
            {
                onTargetReached[i].Invoke();
            }
        }
    }

    public sealed class TraficLight
    {
        public Color LightColor { get; private set; }

        private Timer underlying;

        public TraficLight(TimeSpan lightDelta)
        {
            underlying = new Timer(TimeSpan.FromSeconds(5));
            ResetTimer();
        }

        public void Update()
        {
            if (underlying.Tick()) ResetTimer();
        }

        private void ResetTimer()
        {
            underlying.AddEvent(() =>
            {
                if (LightColor == Color.Red) LightColor = Color.Green;
                else if (LightColor == Color.Green) LightColor = Color.Yellow;
                else LightColor = Color.Red;
            });
        }
    }
}