namespace Assignment.Logic
{
    using Microsoft.Xna.Framework;

    public sealed class ShippingContainer : Container
    {
        public ShippingContainer(int id, Vector2 pos)
            : base(id, pos, 2000)
        { }

        public static ShippingContainer Blue(Vector2 pos)
        {
            return new ShippingContainer(4, pos);
        }

        public static ShippingContainer Red(Vector2 pos)
        {
            return new ShippingContainer(5, pos);
        }
    }
}