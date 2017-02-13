namespace _1._1
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    [DebuggerDisplay("{Count}")]
    public sealed class Counter
    {
        public int Count { get; private set; }
        private List<Target> targets;

        public Counter()
        {
            targets = new List<Target>();
        }
        
        private Counter(int baseCount)
            : this()
        {
            Count = baseCount;
        }

        public static Counter operator +(Counter _0, Counter _1) { return new Counter(_0.Count + _1.Count); }
        public static Counter operator ++(Counter c) { c.Tick(); return c; }

        public void Reset() => Count = 0;
        public void Tick()
        {
            Count++;
            for (int i = 0; i < targets.Count; i++)
            {
                if (Count == targets[i].target) targets[i].action();
            }
        }

        public void OnTarget(int target, Action action)
        {
            if (Count == target) action();
            else targets.Add(new Target(target, action));
        }

        private struct Target : IEquatable<Target>
        {
            public readonly int target;
            public readonly Action action;

            public Target(int t, Action a)
            {
                target = t;
                action = a;
            }

            public bool Equals(Target other)
            {
                return target == other.target;
            }

            public override bool Equals(object obj)
            {
                return obj.GetType() == typeof(Target) ? Equals((Target)obj) : false;
            }

            public override int GetHashCode()
            {
                return target;
            }

            public override string ToString()
            {
                return $"{{ At: {target} Run: {action} }}";
            }
        }
    }
}