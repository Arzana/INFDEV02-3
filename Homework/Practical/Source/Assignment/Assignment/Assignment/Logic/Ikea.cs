namespace Assignment.Logic
{
    using Microsoft.Xna.Framework;

    public sealed class Ikea : Factory<Furniture>
    {
        public Ikea(MainGame game)
            : base(game, 1)
        {
            Position = new Vector2(550, 330);
        }

        protected override Furniture NewProduct()
        {
            return new Furniture(Position + new Vector2(200, 40 - 30 * ProductsToShip.Count), 100);
        }

        protected override Truck NewTruck()
        {
            Vector2 pos = Position + new Vector2(-150, 35);
            return new Truck(Game, pos) { Load = ShippingContainer.Red(pos - new Vector2(-50, 20)) };
        }
    }
}