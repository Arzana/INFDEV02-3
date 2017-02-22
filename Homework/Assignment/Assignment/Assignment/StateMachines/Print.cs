namespace Assignment.StateMachines
{
    using Interfaces;
    using System;

    public class Print : IStateMachine
    {
        public bool Busy { get; private set; }
        public readonly string message;

        public Print(string message)
        {
            this.message = message;
            Busy = true;
        }

        public void Update(float dt)
        {
            Console.WriteLine(message);
            Busy = false;
        }

        public void Reset()
        {
            Busy = true;
        }
    }
}