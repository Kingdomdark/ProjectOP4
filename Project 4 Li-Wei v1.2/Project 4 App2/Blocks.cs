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
        public IBlock Create(int id)
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

    interface IBlock
    {
        void Move();
        void Draw(SpriteBatch spritebatch);
        void SetSprite(Texture2D texture);
    }
    class PointBlock : IBlock
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
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pointblock, position, color);
        }
        public void Move()
        {
            position.X = position.X - 10;
        }
    }

    class BombBlock : IBlock
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
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bombblock, position, color);
        }
        public void Move()
        {
            position.X = position.X - 10;
        }
    }
}