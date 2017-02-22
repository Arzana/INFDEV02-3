namespace Assignment.StateMachines
{
    using Interfaces;

    public class Repeat : IStateMachine
    {
        public bool Busy { get { return true; } }

        private IStateMachine action;

        public Repeat(IStateMachine action)
        {
            this.action = action;
        }

        public void Update(float dt)
        {
            if (!action.Busy) Reset();
            action.Update(dt);
        }

        public void Reset()
        {
            action.Reset();
        }
    }
}