namespace Assignment
{
    using Graphics;
    using Logic;
    using Mentula.BasicContent.Config;
    using Mentula.GuiItems.Items;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class MainGame : Game
    {
        public static Config Config { get; private set; }

        internal SpriteRenderer Renderer { get; private set; }
        private GuiMenu gui;

        internal Mine mine;
        internal Ikea ikea;

        public MainGame()
        {
            Content.RootDirectory = "Content";

            Components.Add(Renderer = new SpriteRenderer(this) { DrawOrder = 0 });
            Components.Add(mine = new Mine(this) { DrawOrder = 1 });
            Components.Add(ikea = new Ikea(this) { DrawOrder = 1 });
        }

        protected override void Initialize()
        {
            Config = ConfigLoader.Load($"{Content.RootDirectory}\\Config.mm");
            IsMouseVisible = Config.Get<bool>("EnableMouse");

            Components.Add(gui = new GuiMenu(this) { DrawOrder = 2 });
            gui.Show();

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            /* Hanle gamepad input. */
            GamePadState gpState = GamePad.GetState(PlayerIndex.One);
            if (gpState.IsConnected)
            {
                if (gpState.IsButtonDown(Buttons.Back)) Exit();
            }

            /* Handle keyboard input. */
            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.Escape)) Exit();

            gui.Mine.Text = mine.ToString();
            gui.Ikea.Text = ikea.ToString();

            if (mine.waitingTruck != null) gui.TruckMine.Text = mine.waitingTruck.ToString();

            base.Update(gameTime);
        }

        protected override bool BeginDraw()
        {
            Renderer.BeginDraw();
            return base.BeginDraw();
        }

        protected override void EndDraw()
        {
            Renderer.EndDraw();
            base.EndDraw();
        }
    }
}
