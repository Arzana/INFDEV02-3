namespace Assignment.Logic
{
    using Microsoft.Xna.Framework;

    public sealed class Ore : Container
    {
        public Ore(Vector2 pos, int startCapacity)
            : base(3, pos, 1000)
        {
            AddContent(startCapacity);
        }
    }
}