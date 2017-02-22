namespace Assignment.StateMachines
{
    using Interfaces;

    public class Sequence : IStateMachine
    {
        public bool Busy { get; private set; }

        private IStateMachine cur, next;
        private IStateMachine s0, s1;

        public Sequence(IStateMachine s0, IStateMachine s1)
        {
            this.s0 = s0;
            this.s1 = s1;
            cur = s0;
            next = s1;
            Busy = true;
        }

        public void Update(float dt)
        {
            if (Busy)
            {
                cur.Update(dt);
                if (!cur.Busy) cur = next;
                if (!next.Busy) Busy = false;
            }
        }

        public void Reset()
        {
            s0.Reset();
            s1.Reset();
            cur = s0;
            Busy = true;
        }
    }
}