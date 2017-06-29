using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D player;
        Texture2D pointblock;
        Texture2D bombblock;

        Player player1;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = false;
            player1 = new Player(new Vector2(0, 380), Color.White);


        }


        public class Player
        {
            private Texture2D player;
            public Vector2 position;
            private Color color;

            public Player(Vector2 position, Color color)
            {
                this.position = position;
                this.color = color;
            }

            public void SetSprite(Texture2D player)
            {
                this.player = player;
            }
            public void Draw(SpriteBatch spriteBatch) //Method to draw the Player Block
            {
                spriteBatch.Draw(player, position, color);
            }
            public void Movement(KeyboardState CurrentState)
            {
                if (CurrentState.IsKeyDown(Keys.Left) == true)
                {
                    this.position.Y -=1;
                }

                if (CurrentState.IsKeyDown(Keys.Right)== true)
                {
                    this.position.Y += 1;
                }
            }


        }

        public abstract class Blocks
        {
            public static Blocks Create(int id)
            {
                if ((id == 1))
                {
                    return new PointBlock(new Vector2(200, 200), Color.White);
                }
                else
                {
                    return new BombBlock(new Vector2(200, 200), Color.White);
                }
//                else
//                {
 //                   throw new Exception("wrong input mate");
  //              }
            }
        }

        public class PointBlock : Blocks
        {
            public Texture2D pointblock;
            public Vector2 position;
            private Color color;

            public PointBlock(Vector2 position, Color color) : base()
            {
                this.position = position;
                this.color = color;
            }

            public void SetSprite(Texture2D pointblock)
            {
                this.pointblock = pointblock;
            }
            public void Update()
            {
                position.X = position.X - 10;
            }
        }


        public class BombBlock : Blocks
        {
            public Texture2D bombblock;
            public Vector2 position;
            private Color color;

            public BombBlock(Vector2 position, Color color) : base()
            {
                this.position = position;
                this.color = color;
            }

            public void SetSprite(Texture2D bombblock)
            {
                this.bombblock = bombblock;
            }
            public void Update()
            {
                position.X = position.X - 10;
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player1 = new Player(new Vector2(0, 380), Color.White);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            Texture2D player = Content.Load<Texture2D>("player");
            player1.SetSprite(player);

            Texture2D pointblock = Content.Load<Texture2D>("pointblock");
            Texture2D bombblock = Content.Load<Texture2D>("bombblock");



        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState kbstate = Keyboard.GetState();
            if (kbstate.IsKeyDown(Keys.Left) == true)
            {
                player1.position.X -= 1;
            }

            if (kbstate.IsKeyDown(Keys.Right) == true)
            {
                player1.position.X += 1;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            player1.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
