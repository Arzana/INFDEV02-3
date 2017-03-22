namespace Assignment.Logic
{
    using Mentula.GuiItems.Core;
    using Microsoft.Xna.Framework;

    public sealed class Truck : DrawableMentulaGameComponent<MainGame>, ISprite
    {
        public int Id { get; private set; }
        public Vector2 Position { get; private set; }
        public Vector2 Scale { get; private set; }
        public Vector2 Velocity { get; private set; }
        public Container Load;

        private Vector3 truck;

        public Truck(MainGame game, Vector2 pos)
            : base(game)
        {
            DrawOrder = 1;
            Position = pos;
            Id = Side() ? 8 : 7;
            game.Components.Add(this);
        }

        public override void Initialize()
        {
            Program.LogAgmnt("Truck", $"initializing truck({Id})", "Logic");
            Scale = new Vector2(MainGame.Config.Get<float>("TruckScale"));
            truck = new Vector3(-100 * Game.Renderer.Scale, 700 * Game.Renderer.Scale, MainGame.Config.Get<float>("TruckSpeedMod"));

            base.Initialize();
        }

        protected override void Dispose(bool disposing)
        {
            Program.LogAgmnt("Truck", $"disposing truck({Id})", "Disp");
            Game.Components.Remove(this);
            base.Dispose(disposing);
        }

        public void Start()
        {
            Velocity = (Side() ? -Vector2.UnitX : Vector2.UnitX) * truck.Z;
        }

        public override void Update(GameTime gameTime)
        {
            if (Velocity != Vector2.Zero)
            {
                Vector2 vloc = Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Position += vloc;
                Load.Position += vloc;

                if (Position.X < truck.X || Position.X > truck.Y) Game.Components.Remove(this);
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

        private bool Side() => Position.Y > MainGame.Config.Get<int>("ResolutionHeight") >> 2;
    }
}