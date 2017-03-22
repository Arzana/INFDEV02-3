namespace Assignment.Graphics
{
    using Mentula.GuiItems.Containers;
    using Mentula.GuiItems.Core;
    using Mentula.GuiItems.Items;
    using Microsoft.Xna.Framework;

    public sealed class GuiMenu : Menu<MainGame>
    {
        public Label Mine, Ikea, TruckMine;
        private FpsCounter fps;

        public GuiMenu(MainGame game)
            : base(game)
        {
            DrawOrder = 2;
            game.Components.Add(this);
            fps = new FpsCounter();
        }

        public override void Initialize()
        {
            SetDefaultFont("MenuFont");
            fps.Initialize();

            Mine = AddDefLbl("LblMine");
            Mine.Position = Game.mine.Position + new Vector2(0, (Mine.Height << 1) * Game.Renderer.Scale);
            Mine.Text = $"Backlog: null";

            Ikea = AddDefLbl("LblIkea");
            Ikea.Position = Game.ikea.Position - new Vector2(0, (Ikea.Height >> 1) * Game.Renderer.Scale);
            Ikea.Text = $"Backlog: null";

            TruckMine = AddDefLbl("LblTrucks");
            TruckMine.MoveRelative(Anchor.Center);
            TruckMine.Text = $"Trucks: null";

            base.Initialize();
        }

        protected override void Dispose(bool disposing)
        {
            Game.Components.Remove(this);
            base.Dispose(disposing);
        }

        public override void Update(GameTime gameTime)
        {
            Mine.Text = $"Backlog: {Game.mine}";
            Ikea.Text = $"Backlog: {Game.ikea}";

            if (Game.mine.waitingTruck != null) TruckMine.Text = $"Trucks: {Game.mine.waitingTruck}";

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            fps.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            DrawString($"Fps: {fps.AverageFps}", Vector2.Zero, Color.White);
            base.Draw(gameTime);
        }

        private Label AddDefLbl(string name)
        {
            Label lbl = AddLabel();
            lbl.Name = name;
            lbl.AutoRefresh = true;
            lbl.AutoSize = true;
            lbl.BackColor = Color.Transparent;
            return lbl;
        }
    }
}