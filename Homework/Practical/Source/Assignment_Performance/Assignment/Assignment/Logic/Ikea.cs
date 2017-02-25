namespace Assignment.Logic
{
    using Microsoft.Xna.Framework;

    public sealed class Ikea : Factory<Furniture>
    {
        private Vector3 offsetp;
        private Vector4 offsett;

        public Ikea(MainGame game)
            : base(game, 1)
        { }

        public override void Initialize()
        {
            Position = new Vector2(550 * Game.Renderer.Scale, 330 * Game.Renderer.Scale);

            offsetp.X = 200 * Game.Renderer.Scale;
            offsetp.Y = 40 * Game.Renderer.Scale;
            offsetp.Z = 30 * Game.Renderer.Scale;

            offsett.X = -150 * Game.Renderer.Scale;
            offsett.Y = 35 * Game.Renderer.Scale;
            offsett.Z = -50 * Game.Renderer.Scale;
            offsett.W = 20 * Game.Renderer.Scale;

            base.Initialize();
        }

        protected override Furniture NewProduct(int amount)
        {
            return new Furniture(Position + new Vector2(offsetp.X, offsetp.Y - offsetp.Z * ProductsToShip.Count), amount);
        }

        protected override Truck NewTruck()
        {
            Vector2 pos = Position + new Vector2(offsett.X, offsett.Y);
            return new Truck(Game, pos) { Load = ShippingContainer.Red(pos - new Vector2(offsett.Z, offsett.W)) };
        }
    }
}