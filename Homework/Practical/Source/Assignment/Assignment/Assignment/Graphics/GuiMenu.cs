namespace Assignment.Graphics
{
    using Mentula.GuiItems.Containers;
    using Mentula.GuiItems.Core;
    using Mentula.GuiItems.Items;
    using Microsoft.Xna.Framework;

    public sealed class GuiMenu : Menu<MainGame>
    {
        public Label Mine, Ikea, TruckMine;

        public GuiMenu(MainGame game)
            : base(game)
        { }

        public override void Initialize()
        {
            SetDefaultFont("MenuFont");

            Mine = AddDefLbl();
            Mine.Position = Game.mine.Position + new Vector2(0, Mine.Height << 1);

            Ikea = AddDefLbl();
            Ikea.Position = Game.ikea.Position - new Vector2(0, Ikea.Height >> 1);

            TruckMine = AddDefLbl();
            TruckMine.MoveRelative(Anchor.Middle);

            base.Initialize();
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