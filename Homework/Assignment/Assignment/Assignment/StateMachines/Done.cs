namespace Assignment.StateMachines
{
    using Interfaces;

    public class Done : IStateMachine
    {
        public bool Busy { get; private set; }
        public readonly string message;

        public Done(string message)
        {
            this.message = message;
            Busy = true;
        }

        public void Update(float dt)
        {
            Busy = false;
        }

        public void Reset()
        {
            Busy = true;
        }
    }
}