namespace Assignment
{
    using Graphics;
    using Logic;
    using Mentula.BasicContent.Config;
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
            Renderer = new SpriteRenderer(this);
            mine = new Mine(this);
            ikea = new Ikea(this);
        }

        protected override void Initialize()
        {
            Config = ConfigLoader.Load($"{Content.RootDirectory}\\Config.mm");
            IsMouseVisible = Config.Get<bool>("EnableMouse");

            /* The GUI is added in initialize because it depends on the GraphicsDevice wich is not yet available in the constructor. */
            gui = new GuiMenu(this);
            gui.Show();

            base.Initialize();
        }

        protected override void Dispose(bool disposing)
        {
            Renderer.Dispose();
            mine.Dispose();
            ikea.Dispose();
            gui.Dispose();
            base.Dispose(disposing);
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
