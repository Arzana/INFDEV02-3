namespace Assignment.Logic
{
    using Microsoft.Xna.Framework;

    public sealed class Mine : Factory<Ore>
    {
        private Vector3 offsetp;
        private Vector3 offsett;

        public Mine(MainGame game)
            : base(game, 2)
        { }

        public override void Initialize()
        {
            Position = new Vector2(50 * Game.Renderer.Scale, 50 * Game.Renderer.Scale);

            offsetp.X = -50 * Game.Renderer.Scale;
            offsetp.Y = 40 * Game.Renderer.Scale;
            offsetp.Z = 30 * Game.Renderer.Scale;

            offsett.X = 150 * Game.Renderer.Scale;
            offsett.Y = 40 * Game.Renderer.Scale;
            offsett.Z = 10 * Game.Renderer.Scale;

            base.Initialize();
        }

        protected override Ore NewProduct(int amount)
        {
            return new Ore(Position + new Vector2(offsetp.X, offsetp.Y - offsetp.Z * ProductsToShip.Count), amount);
        }

        protected override Truck NewTruck()
        {
            Vector2 pos = Position + new Vector2(offsett.X, offsett.Y);
            return new Truck(Game, pos) { Load = ShippingContainer.Blue(pos - new Vector2(0, offsett.Z)) };
        }
    }
}