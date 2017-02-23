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
        public Vector2 Scale { get { return new Vector2(.5f); } }
        public Vector2 Position { get; protected set; }
        public List<TProduct> ProductsToShip { get; private set; }

        public Truck waitingTruck;

        private float waitTime;

        protected Factory(MainGame game, int textureId)
            : base(game)
        {
            Id = textureId;
            ProductsToShip = new List<TProduct>();
        }

        public override void Update(GameTime gameTime)
        {
            if (waitingTruck != null)
            {
                if (ProductsToShip.Count > 0)
                {
                    TProduct lastProduct = ProductsToShip.Last();
                    if (lastProduct.CurrentCapacity >= 100)
                    {
                        if (!waitingTruck.Load.AddContent(100)) waitingTruck = null;
                        lastProduct.AddContent(-100);
                    }
                }
            }
            else Game.Components.Add(waitingTruck = NewTruck());

            if (ProductsToShip.Count > 4) return;
            if ((waitTime += (float)gameTime.ElapsedGameTime.TotalSeconds) >= 1f)
            {
                TProduct lastProduct = ProductsToShip.LastOrDefault();
                if (lastProduct?.CurrentCapacity < lastProduct?.MaxCapacity) lastProduct.AddContent(110);
                else ProductsToShip.Add(NewProduct());
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

        protected abstract TProduct NewProduct();
        protected abstract Truck NewTruck();

        public override string ToString()
        {
            int cur = 0, max = 0;
            for (int i = 0; i < ProductsToShip.Count; i++)
            {
                cur += ProductsToShip[i].CurrentCapacity;
                max += ProductsToShip[i].MaxCapacity;
            }
            return $"{cur}|{max}";
        }
    }
}