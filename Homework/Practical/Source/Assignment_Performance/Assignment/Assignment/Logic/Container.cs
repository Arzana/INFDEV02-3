namespace Assignment.Logic
{
    using Microsoft.Xna.Framework;
    using System.Diagnostics;

    [DebuggerDisplay("{ToString()}")]
    public abstract class Container : Sprite
    {
        public readonly int MaxCapacity;
        public int CurrentCapacity { get; private set; }

        protected Container(int id, Vector2 pos, int maxCap)
            : base(id, pos, new Vector2(MainGame.Config.Get<float>("ContainerScale")))
        {
            MaxCapacity = maxCap;
        }

        public bool AddContent(int amount)
        {
            if (CurrentCapacity + amount > MaxCapacity) return false;

            CurrentCapacity += amount;
            return true;
        }

        public override string ToString()
        {
            return $"{CurrentCapacity}|{MaxCapacity}";
        }
    }
}