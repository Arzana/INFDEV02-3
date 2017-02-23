namespace Assignment.Logic
{
    using Mentula.GuiItems.Core;
    using Microsoft.Xna.Framework;

    public sealed class Truck : DrawableMentulaGameComponent<MainGame>, ISprite
    {
        public int Id { get; private set; }
        public Vector2 Position { get; private set; }
        public Vector2 Scale { get { return new Vector2(.25f); } }
        public Vector2 Velocity { get; private set; }
        public Container Load;

        public Truck(MainGame game, Vector2 pos)
            : base(game)
        {
            DrawOrder = 1;
            Position = pos;
            Id = Side() ? 8 : 7;
        }

        public void Start()
        {
            Velocity = (Side() ? -Vector2.UnitX : Vector2.UnitX) * 16;
        }

        public override void Update(GameTime gameTime)
        {
            if (Velocity != Vector2.Zero)
            {
                Vector2 vloc = Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Position += vloc;
                Load.Position += vloc;

                if (Position.X < -100 || Position.X > 700) Game.Components.Remove(this);
            }
            else if (Load.CurrentCapacity == Load.MaxCapacity) Start();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.Renderer.DrawBatch(this);
            if (Load != null) Game.Renderer.DrawBatch(Load);

            base.Draw(gameTime);
        }

        public override string ToString()
        {
            return Load.ToString();
        }

        private bool Side() => Position.X > MainGame.Config.Get<int>("ResolutionWidth") >> 2;
    }
}