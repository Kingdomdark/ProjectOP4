using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Project_4_App
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TouchCollection touchCollection;

        Texture2D player;
        Texture2D pointblock;
        Texture2D bombblock;

        Player player1;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

            player1 = new Player(new Vector2(0, 800), Color.White);

            
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

            // Load textures
            player = Content.Load<Texture2D>("player");
            player1.SetSprite(player);

            pointblock = Content.Load<Texture2D>("pointblock");
            bombblock = Content.Load<Texture2D>("bombblock");



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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();
            // TODO: Add your update logic here
            touchCollection = TouchPanel.GetState();
            if(touchCollection.Count > 0)
            {
                if (touchCollection[0].State == TouchLocationState.Pressed)
                {
                    //if(touchCollection[0].Position.X > 0)
                    //{
                    //    player1.Move();
                    //}
                    player1.MoveTest();
                }
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
        //Make a player class
        public class Player
        {
            private Texture2D player;
            private Vector2 position;
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
            public void MoveTest()
            {
                this.position.Y = this.position.Y + 50;
            }
            public void MoveLeft()
            {
                this.position.Y = this.position.Y - 1;
            }
            public void MoveRight()
            {
                this.position.Y = this.position.Y + 1;
            }
        }

        //Simple Factory Design Pattern for spawning the blocks
        abstract class Blocks
        {
            public static Blocks Create(int id)
            {
                if ((id == 1))
                {
                    return new PointBlock(new Vector2(200, 200), Color.White);
                }
                if ((id == 2))
                {
                    return new BombBlock(new Vector2(200, 200), Color.White);
                }
                else
                {
                    throw new Exception("wrong input mate");
                }
            }
        }

        class PointBlock : Blocks
        {
            public Texture2D pointblock;
            private Vector2 position;
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

        class BombBlock : Blocks
        {
            public Texture2D bombblock;
            private Vector2 position;
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
        //Visitor Design Pattern
        //interface IVisitor
        //{
        //    void onBlock();
        //    void onBomb();
        //}

        //class BlockVisitor : IVisitor
        //{
        //    public void onBlock()
        //    {

        //    }

        //    public void onBomb()
        //    {

        //    }
        //}


    }
}
