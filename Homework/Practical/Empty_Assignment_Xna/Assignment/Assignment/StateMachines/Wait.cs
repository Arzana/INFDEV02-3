namespace Assignment.StateMachines
{
    using Interfaces;
    using System;

    public class Wait : IStateMachine
    {
        public bool Busy { get; private set; }

        private Func<bool> condition;

        public Wait(Func<bool> condition)
        {
            this.condition = condition;
            Busy = true;
        }

        public void Update(float dt)
        {
            if (condition()) Busy = false;
        }

        public void Reset()
        {
            Busy = true;
        }
    }
}