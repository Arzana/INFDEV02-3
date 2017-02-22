namespace Assignment
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    public class GameState : IComponent
    {
        private List<ITruck> trucks;
        private List<IStateMachine> processes;
        private IFactory factory0, factory1;
        private Texture2D background;

        public GameState(Texture2D background, Texture2D mineCart, Texture2D productBox, Texture2D volvo, Texture2D mine, Texture2D ikea, Texture2D oreContainer, Texture2D productContainer)
        {
            this.background = background;
            factory0 = new Mine(new Vector2(100, 70), mine, oreContainer, mineCart, volvo);
            factory1 = null;
            processes = new List<IStateMachine>();
            trucks = new List<ITruck>();
        }

        public void Update(float dt)
        {
            trucks.RemoveAll(truck => truck.Position.X < -50 || truck.Position.X > 1000);

            for (int i = 0; i < processes.Count; i++)
            {
                processes[i].Update(dt);
            }

            for (int i = 0; i < trucks.Count; i++)
            {
                trucks[i].Update(dt);
            }

            if (factory0 != null) factory0.Update(dt);
            if (factory1 != null) factory1.Update(dt);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(background, Vector2.Zero, Color.White);

            for (int i = 0; i < trucks.Count; i++)
            {
                trucks[i].Draw(batch);
            }

            if (factory0 != null) factory0.Draw(batch);
            if (factory1 != null) factory1.Draw(batch);
        }
    }
}