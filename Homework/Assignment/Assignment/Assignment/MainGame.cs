namespace Assignment
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class MainGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch batch;

        private IStateMachine sm;
        private GameState state;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            batch = new SpriteBatch(GraphicsDevice);

            Texture2D volvo = Content.Load<Texture2D>("volvo");
            Texture2D mine = Content.Load<Texture2D>("mine");
            Texture2D ore_container = Content.Load<Texture2D>("ore_container");
            Texture2D product_container = Content.Load<Texture2D>("product_container");
            Texture2D ikea = Content.Load<Texture2D>("ikea");
            Texture2D background = Content.Load<Texture2D>("background");
            Texture2D mine_cart = Content.Load<Texture2D>("mine_cart");
            Texture2D product_box = Content.Load<Texture2D>("product_box");

            state = new GameState(background, mine_cart, product_box, volvo, mine, ikea, ore_container, product_container);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            state.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LimeGreen);

            batch.Begin();
            state.Draw(batch);
            batch.End();

            base.Draw(gameTime);
        }
    }
}