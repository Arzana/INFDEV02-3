namespace Assignment.StateMachines
{
    using Interfaces;

    public class Timer : IStateMachine
    {
        public bool Busy { get; private set; }
        public float Time { get; private set; }

        private float initial;

        public Timer(float time)
        {
            initial = time;
            Time = time;
            Busy = true;
        }

        public void Update(float dt)
        {
            Time -= dt;
            if (Time <= 0) Busy = false;
        }

        public void Reset()
        {
            Time = initial;
            Busy = true;
        }
    }
}