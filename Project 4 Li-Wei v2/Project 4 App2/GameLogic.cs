using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Project_4_App2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameLogic : Microsoft.Xna.Framework.Game
    {
        int count = 0; //created so you know you will spawn a bomb or a block
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SetSpriteVisitor s_visitor;

        List<IBlock> BlocksList;
        AndroidPlayer player1;

        public GameLogic() 
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

            player1 = new AndroidPlayer(new Vector2(0, 800), Color.White);//creates an instance of the androidplayer
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
            BlocksList = new List<IBlock>();//make a list of blocks available for storage
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()  //read top part, which was already created by monogame
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            // Load the textures
            Texture2D androidplayer = Content.Load<Texture2D>("androidplayer");
            player1.SetSprite(androidplayer);
            Texture2D pointblock = Content.Load<Texture2D>("pointblock");
            Texture2D bombblock = Content.Load<Texture2D>("bombblock");

            s_visitor = new SetSpriteVisitor(pointblock, bombblock);
            //foreach (var block in BlocksList)   //for each block in the list, visit will be called, which sets the sprite, depending on if 
            //{ //the block is a PointBlock, or the block is a BombBlock
               // block.Visit(s_visitor); //calls the visit method
            //}


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
        protected override void Update(GameTime gameTime) //read above
        {
            bool EndGame = false;
            int CaughtBlocks = 0;
            int DroppedBlocks = 0;
            BlocksFactory blocksFactory = new BlocksFactory(); //creates instance of the blocksfactory

            //// TODO: Add your update logic here

            var elapsedtime = gameTime.TotalGameTime.Seconds; //gets the elapsed time

            if (elapsedtime % 5 == 0) //if the elapsed time is divisible by 5,
            {
                if (count < 5) //if the count is smaller than 5, spawn a pointblock
                {
                    BlocksList.Add(blocksFactory.Create(1));//Create an instance of Pointblock
                    count += 1; //adds 1 to the count, so you will eventually drop a bomb... read further down
                }
                else //so if the count is greater or equal to 5, spawn a bomb
                {
                    BlocksList.Add(blocksFactory.Create(2));//Create an instance of BombBlock
                    count = 0;//sets the counter back to 0, so the game will spawn PointBlocks again
                }

                BlocksList[BlocksList.Count - 1].Visit(s_visitor); //visist the block in the blocklist that just been created
            }

            foreach (var block in BlocksList)//for every block in the list...
            {
                block.Update(gameTime);
            }

            if (DroppedBlocks == 3)
            {
                EndGame = true;
            }
            player1.Update(gameTime);

            //make the logic for catching the blocks. if bomb is caught, end the game. if 3 blocks reach the ground, end the game.


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

            spriteBatch.Begin();//Begins a sprite batch operation
            player1.Draw(spriteBatch);//Draw the player1, which is an instance of the AndroidPlayer
            foreach (var block in BlocksList)//for every block in the list...
            {
                block.Draw(spriteBatch);//call the method draw, which draws the blocks
            }
            spriteBatch.End();//end a sprite batch operation
            base.Draw(gameTime);
        }
    }
}