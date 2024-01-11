using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGame.GameObjects;
using PongGame.Managers;

namespace PongGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int screenWidth = 1920;
        public static int screenHeight = 1080;
        private static System.Drawing.Rectangle collisionBox = new System.Drawing.Rectangle(10, 10, screenWidth - 20, screenHeight - 20);

        Texture2D topColliderTexture, bottomColliderTexture, playerColliderTextures;

        Player playerOne, playerTwo;
        Ball ball;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Creating the two players
            playerOne = new Player((-screenWidth / 2 - 100) + 200, -225, 100, 450, false);
            playerTwo = new Player((screenWidth / 2 - 100) - 200, -225, 100, 450, true);
            ball = new Ball(-15, -15, 30, 30);

            // Resize window
            _graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.ApplyChanges();

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            playerOne.playerTexture = Content.Load<Texture2D>("BarBlueGray");
            playerTwo.playerTexture = Content.Load<Texture2D>("BarGreenGray");
            ball.ballTexture = Content.Load<Texture2D>("SquareBallRed");

            /*topColliderTexture = Content.Load<Texture2D>("SquareBallBlue");
            bottomColliderTexture = Content.Load<Texture2D>("SquareBallGreen");
            playerColliderTextures = Content.Load<Texture2D>("SquareBallRed");*/
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // user input
            KeyboardManager.CheckForInput(playerOne, playerTwo);

            // ball movement
            ball.CheckCollision(playerOne, playerTwo, collisionBox);
            ball.Move();

            // check for restart
            if (KeyboardManager.CheckForRestart())
            {
                ball = new Ball(-15, -15, 30, 30, ball.ballTexture);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.Draw(playerOne.playerTexture, new Rectangle((int)playerOne.position.X, (int)playerOne.position.Y, 200, 450), Color.White);
            _spriteBatch.Draw(playerTwo.playerTexture, new Rectangle((int)playerTwo.position.X, (int)playerTwo.position.Y, 200, 450), Color.White);
            _spriteBatch.Draw(ball.ballTexture, new Rectangle((int)ball.position.X, (int)ball.position.Y, 30, 30), Color.White);


            // Collision Boxes

            /*_spriteBatch.Draw(playerColliderTextures, XnaConverter.ConvertSystemDrawingToXnaRectangle(playerOne.collisionBox), Color.White);
            _spriteBatch.Draw(playerColliderTextures, XnaConverter.ConvertSystemDrawingToXnaRectangle(playerTwo.collisionBox), Color.White);
            _spriteBatch.Draw(topColliderTexture, XnaConverter.ConvertSystemDrawingToXnaRectangle(playerOne.topCollider), Color.White);
            _spriteBatch.Draw(bottomColliderTexture, XnaConverter.ConvertSystemDrawingToXnaRectangle(playerOne.bottomCollider), Color.White);
            _spriteBatch.Draw(topColliderTexture, XnaConverter.ConvertSystemDrawingToXnaRectangle(playerTwo.topCollider), Color.White);
            _spriteBatch.Draw(bottomColliderTexture, XnaConverter.ConvertSystemDrawingToXnaRectangle(playerTwo.bottomCollider), Color.White);*/

            _spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}