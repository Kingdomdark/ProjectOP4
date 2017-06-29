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
    interface IPlayer
    {
        void SetSprite(Texture2D player);
        void Draw(SpriteBatch spriteBatch);
        void MoveLeft();
        void MoveRight();

    }
    public class PlayerAdapter : IPlayer
    {
        DesktopPlayer thePlayer;

        public PlayerAdapter(DesktopPlayer newPlayer, Vector2 position, Color color)
        {
            thePlayer = newPlayer;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            thePlayer.Draw(spriteBatch);
        }

        public void MoveLeft()
        {
            thePlayer.MoveLeft();
        }

        public void MoveRight()
        {
            thePlayer.MoveRight();
        }

        public void SetSprite(Texture2D player)
        {
            this.player = player;//needs help
        }
    }
    public class AndroidPlayer : IPlayer
    {
        private Texture2D androidplayer;
        private Vector2 position;
        private Color color;

        public AndroidPlayer(Vector2 position, Color color)
        {
            this.position = position;
            this.color = color;
        }

        public void SetSprite(Texture2D androidplayer)
        {
            this.androidplayer = androidplayer;
        }

        public void Draw(SpriteBatch spriteBatch) //Method to draw the Player Block
        {
            spriteBatch.Draw(androidplayer, position, color);
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

    public class DesktopPlayer : IPlayer
    {
        private Texture2D desktopplayer;
        private Vector2 position;
        private Color color;

        public DesktopPlayer(Vector2 position, Color color)
        {
            this.position = position;
            this.color = color;
        }

        public void SetSprite(Texture2D player)
        {
            this.desktopplayer = player;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(desktopplayer, position, color);
        }
        public void MoveTest()
        {
            this.position.X = this.position.X + 50;
        }
        public void MoveLeft()
        {
            this.position.X = this.position.X - 1;
        }
        public void MoveRight()
        {
            this.position.X = this.position.X + 1;
        }
    }
}