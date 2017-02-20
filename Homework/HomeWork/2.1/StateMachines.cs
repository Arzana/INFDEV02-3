namespace _2._1
{
    using System;
    using static System.Console;

    public interface IStateMachine
    {
        bool Done { get; }

        void Update(float num);
        void Reset();
    }

    public sealed class Wait : IStateMachine
    {
        public bool Done { get; private set; }
        public float Remaining { get; private set; }
        private float init;

        public Wait(float initial)
        {
            Remaining = init = initial;
        }

        public void Update(float amount)
        {
            if (Done) return;
            Remaining -= amount;

            if (Remaining <= 0)
            {
                amount = 0;
                Done = true;
            }
        }

        public void Reset()
        {
            Done = false;
            Remaining = init;
        }
    }

    public sealed class Print : IStateMachine
    {
        public bool Done { get; private set; }
        private string msg;

        public Print(string msg)
        {
            this.msg = msg;
        }

        public void Update(float n)
        {
            if (Done) return;
            WriteLine(msg);
            Done = true;
        }

        public void Reset()
        {
            Done = false;
        }
    }

    public sealed class Sequence : IStateMachine
    {
        public bool Done { get; private set; }
        private IStateMachine _0, _1;

        public Sequence(IStateMachine machine0, IStateMachine machine1)
        {
            _0 = machine0;
            _1 = machine1;
        }

        public void Update(float num)
        {
            if (Done) return;

            if (!_0.Done) _0.Update(num);
            else if (!_1.Done) _1.Update(num);
            else Done = true;
        }

        public void Reset()
        {
            Done = false;
            _0.Reset();
            _1.Reset();
        }
    }

    public sealed class Repeat : IStateMachine
    {
        public bool Done { get { return false; } }
        IStateMachine machine;

        public Repeat(IStateMachine machine)
        {
            this.machine = machine;
        }

        public void Update(float num)
        {
            machine.Update(num);
            if (machine.Done) machine.Reset();
        }

        public void Reset() => machine.Reset();
    }
}