namespace Assignment.Graphics
{
    using Mentula.GuiItems.Containers;
    using Mentula.GuiItems.Core;
    using Mentula.GuiItems.Items;
    using Microsoft.Xna.Framework;

    public sealed class GuiMenu : Menu<MainGame>
    {
        public Label Mine, Ikea, TruckMine, Fps;
        private FpsCounter fpsCnt;

        public GuiMenu(MainGame game)
            : base(game)
        {
            game.Components.Add(fpsCnt = new FpsCounter(game));
        }

        public override void Initialize()
        {
            SetDefaultFont("MenuFont");

            Fps = AddDefLbl();
            Fps.MoveRelative(Anchor.Left | Anchor.Top);

            Mine = AddDefLbl();
            Mine.Position = Game.mine.Position + new Vector2(0, (Mine.Height << 1) * Game.Renderer.Scale);

            Ikea = AddDefLbl();
            Ikea.Position = Game.ikea.Position - new Vector2(0, (Ikea.Height >> 1) * Game.Renderer.Scale);

            TruckMine = AddDefLbl();
            TruckMine.MoveRelative(Anchor.Middle);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            Fps.Text = $"Fps: {fpsCnt.AvrgFps}";
            base.Update(gameTime);
        }

        private Label AddDefLbl()
        {
            Label btn = AddLabel();
            btn.AutoSize = true;
            btn.BackColor = Color.Transparent;
            return btn;
        }
    }
}