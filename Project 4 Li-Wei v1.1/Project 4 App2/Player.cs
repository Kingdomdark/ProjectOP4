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
}