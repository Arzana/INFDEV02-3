namespace Assignment.Logic
{
    using Microsoft.Xna.Framework;

    public sealed class Mine : Factory<Ore>
    {
        public Mine(MainGame game)
            : base(game, 2)
        {
            Position = new Vector2(50, 50);
        }

        protected override Ore NewProduct()
        {
            return new Ore(Position + new Vector2(-50, 40 - 30 * ProductsToShip.Count), 100);
        }

        protected override Truck NewTruck()
        {
            Vector2 pos = Position + new Vector2(150, 40);
            return new Truck(Game, pos) { Load = ShippingContainer.Blue(pos - new Vector2(0, 10)) };
        }
    }
}