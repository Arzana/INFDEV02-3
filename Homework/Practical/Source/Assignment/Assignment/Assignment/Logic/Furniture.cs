namespace Assignment.Logic
{
    using Microsoft.Xna.Framework;

    public sealed class Furniture : Container
    {
        public Furniture(Vector2 pos, int startCapacity)
            : base(6, pos, 1000)
        {
            AddContent(startCapacity);
        }
    }
}