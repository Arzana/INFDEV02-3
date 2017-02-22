namespace Assignment
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class Ore : IContainer
    {
        public Vector2 Position { get; set; }
        public int CurrentAmount { get; private set; }
        public int MaxCapacity { get { return 1000; } }

        private Texture2D texture;

        public Ore(int amount, Texture2D texture)
        {
            this.texture = texture;
            AddContent(amount);
        }

        public bool AddContent(int amount)
        {
            if (CurrentAmount + amount > MaxCapacity)
            {
                Console.WriteLine("Too many...");
                return false;
            }

            CurrentAmount += amount;
            return true;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, Position, Color.White);
        }
    }
}
