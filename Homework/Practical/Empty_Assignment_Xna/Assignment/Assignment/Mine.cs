namespace Assignment
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using StateMachines;
    using System;
    using System.Collections.Generic;

    public class Mine : IFactory
    {
        public Vector2 Position { get; private set; }
        public List<IContainer> ProductsToShip { get; private set; }

        private Texture2D mine, oreContainer, oreBox, truck;
        private List<IStateMachine> processes;
        private ITruck waitingTruck;
        private bool isTruckReady;

        public Mine(Vector2 pos, Texture2D mineTexture, Texture2D oreContainerTexture, Texture2D oreBoxTexture, Texture2D truckTexture)
        {
            processes = new List<IStateMachine>();
            ProductsToShip = new List<IContainer>();

            mine = mineTexture;
            oreContainer = oreContainerTexture;
            oreBox = oreBoxTexture;
            truck = truckTexture;

            Position = pos;
            processes.Add(new Sequence(new Timer(0.1f), new Call(new AddOreToMine(this))));
        }

        public ITruck GetReadyTruck()
        {
            throw new NotImplementedException();
        }

        public void Update(float dt)
        {
            for (int i = 0; i < processes.Count; i++)
            {
                processes[i].Update(dt);
            }
        }

        public void Draw(SpriteBatch batch)
        {
            for (int i = 0; i < ProductsToShip.Count; i++)
            {
                ProductsToShip[i].Draw(batch);
            }

            batch.Draw(mine, Position, Color.White);
        }

        public class AddOreToMine : IAction
        {
            private Mine mine;

            public AddOreToMine(Mine parent)
            {
                mine = parent;
            }

            public void Run()
            {
                Vector2 orePos = new Vector2(-80, 40 + -30 * mine.ProductsToShip.Count);
                mine.ProductsToShip.Add(CreateOreBox(mine.Position + orePos));
            }

            public Ore CreateOreBox(Vector2 position)
            {
                return new Ore(100, mine.oreBox) { Position = position };
            }
        }
    }
}
