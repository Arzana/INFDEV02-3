namespace Assignment.Logic
{
    using Mentula.GuiItems.Core;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Factory<TProduct> : DrawableMentulaGameComponent<MainGame>, ISprite
        where TProduct : Container
    {
        public int Id { get; private set; }
        public Vector2 Scale { get; private set; }
        public Vector2 Position { get; protected set; }
        public List<TProduct> ProductsToShip { get; private set; }

        public Truck waitingTruck;
        private float waitTime, productionTime;
        private int loadPerTick, maxProducts, productAmnt;

        protected Factory(MainGame game, int textureId)
            : base(game)
        {
            DrawOrder = 1;
            Id = textureId;
            ProductsToShip = new List<TProduct>();
            game.Components.Add(this);
        }

        public override void Initialize()
        {
            Program.LogAgmnt("Factory", $"initializing factory({Id})", "Logic");
            Scale = new Vector2(MainGame.Config.Get<float>("FactoryScale"));
            loadPerTick = MainGame.Config.Get<int>("TruckLoadPerTick");
            maxProducts = MainGame.Config.Get<int>("MaxFactoryBuffer");
            productionTime = MainGame.Config.Get<float>("FactoryProductionTime");
            productAmnt = MainGame.Config.Get<int>("FactoryProductionAmount");

            base.Initialize();
        }

        protected override void Dispose(bool disposing)
        {
            Program.LogAgmnt("Factory", $"disposing factory({Id})", "Disp");
            waitingTruck?.Dispose();
            Game.Components.Remove(this);
            base.Dispose(disposing);
        }

        public override void Update(GameTime gameTime)
        {
            if (waitingTruck != null)
            {
                if (ProductsToShip.Count > 0)
                {
                    TProduct lastProduct = ProductsToShip.Last();
                    if (lastProduct.CurrentCapacity >= loadPerTick)
                    {
                        if (!waitingTruck.Load.AddContent(loadPerTick)) waitingTruck = null;
                        lastProduct.AddContent(-loadPerTick);
                    }
                }
            }
            else waitingTruck = NewTruck();

            if (ProductsToShip.Count > maxProducts) return;
            if ((waitTime += (float)gameTime.ElapsedGameTime.TotalSeconds) >= productionTime)
            {
                TProduct lastProduct = ProductsToShip.LastOrDefault();
                if (lastProduct?.CurrentCapacity < lastProduct?.MaxCapacity) lastProduct.AddContent(productAmnt);
                else ProductsToShip.Add(NewProduct(productAmnt));
                waitTime = 0;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.Renderer.DrawBatch(this);

            for (int i = 0; i < ProductsToShip.Count; i++)
            {
                Game.Renderer.DrawBatch(ProductsToShip[i]);
            }

            base.Draw(gameTime);
        }

        protected abstract TProduct NewProduct(int amount);
        protected abstract Truck NewTruck();

        public override string ToString()
        {
            int cur = 0, max = 0;
            for (int i = 0; i < ProductsToShip.Count; i++)
            {
                cur += ProductsToShip[i].CurrentCapacity;
                max += ProductsToShip[i].MaxCapacity;
            }
            return $"{cur:0000}|{max}";
        }
    }
}