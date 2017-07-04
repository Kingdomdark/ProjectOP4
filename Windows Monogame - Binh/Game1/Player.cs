﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
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
                this.position.Y -= 1;
            }

            if (CurrentState.IsKeyDown(Keys.Right) == true)
            {
                this.position.Y += 1;
            }
        }


    }
}