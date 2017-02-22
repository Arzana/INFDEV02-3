namespace Assignment.StateMachines
{
    using Interfaces;

    public class Call : IStateMachine
    {
        public bool Busy { get; private set; }

        private IAction action;

        public Call(IAction action)
        {
            this.action = action;
            Busy = true;
        }

        public void Update(float dt)
        {
            action.Run();
            Busy = false;
        }

        public void Reset()
        {
            Busy = true;
        }
    }
}