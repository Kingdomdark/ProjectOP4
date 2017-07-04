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
    //Simple Factory Design Pattern for spawning the blocks
    class BlocksFactory
    {
        static Random _r = new Random();
        int RandomNumber = _r.Next(300,900);
        public IBlock Create(int id)
        {
            if ((id == 1)) //if the id equals 1, make an instance of PointBlock
            {
                return new PointBlock(new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, RandomNumber), Color.White);
            }
            if ((id == 2)) //if the id equals 2, make an instance of BombBlock
            {
                return new BombBlock(new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, RandomNumber), Color.White);
            }
            else 
            {
                throw new Exception("wrong input mate");
            }
        }
    }
    interface IBlockVisitor
    {
        void onBlock(PointBlock block);
        void onBomb(BombBlock block);
    }
    class SetSpriteVisitor : IBlockVisitor //visitor to set the sprite, depending on which class the methods are called
    {
        private Texture2D pointblock;
        private Texture2D bombblock;
        public SetSpriteVisitor(Texture2D pointblock, Texture2D bombblock)
        {
            this.pointblock = pointblock;
            this.bombblock = bombblock;
        }
        public void onBlock(PointBlock block)
        {
            block.SetSprite(pointblock);
        }
        public void onBomb(BombBlock block)
        {
            block.SetSprite(bombblock);
        }
    }
    interface IBlock //interface for the Blocks
    {
        void Draw(SpriteBatch spritebatch);
        void SetSprite(Texture2D texture);
        void Visit(IBlockVisitor v);
        void Update(GameTime gameTime);
    }
    class PointBlock : IBlock
    {
        public Texture2D pointblock;
        private Vector2 position;
        private Color color;
        static Random _r = new Random();

        public PointBlock(Vector2 position, Color color) : base() //constructor for creating the bombblock
        {
            this.position = position;
            this.color = color;
        }

        public void Visit(IBlockVisitor v) //when visited, returns loads the sprite depending on the type of block, in this case an pointblock
        {
            v.onBlock(this); //needs help
        }
        public void SetSprite(Texture2D pointblock) //sets the sprite, so the sprite will be loaded
        {
            this.pointblock = pointblock;
        }
        public void Draw(SpriteBatch spriteBatch) //method to draw the pointblock
        {
            spriteBatch.Draw(pointblock, position, color);
        }
        public void Update(GameTime gameTime) //method to move the pointblock
        {
            position.X -= 1;
        }

    }

    class BombBlock : IBlock
    {
        private Texture2D bombblock;
        private Vector2 position;
        private Color color;

        public BombBlock(Vector2 position, Color color) : base() //constructor for creating the bombblock
        {
            this.position = position;
            this.color = color;
        }
        public void Visit(IBlockVisitor v) //when visited, returns loads the sprite depending on the type of block, in this case an bombblock
        {
            v.onBomb(this);//needs help
        }
        public void SetSprite(Texture2D bombblock) //sets the sprite, so the sprite will be loaded
        {
            this.bombblock = bombblock;
        }
        public void Draw(SpriteBatch spriteBatch) //method to draw the bombblock
        {
            spriteBatch.Draw(bombblock, position, color);
        }
        public void Update(GameTime gameTime) //method to move the bombblock
        {
            position.X -= 1;
        }
    }
}