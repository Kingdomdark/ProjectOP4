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
        void SetSprite(Texture2D desktopplayer);
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gametime);
    }
    public class PlayerAdapter : IPlayer
    {
        private Texture2D desktopplayer;
        private DesktopPlayer thePlayer;

        public PlayerAdapter(DesktopPlayer newPlayer, Vector2 position, Color color)
        {
            thePlayer = newPlayer;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            thePlayer.Draw(spriteBatch);
        }

        public void Update(GameTime gametime)
        {
            thePlayer.Update(gametime);
        }
        
        public void SetSprite(Texture2D desktopplayer)
        {
            thePlayer.SetSprite(desktopplayer);
        }
    }
    public class AndroidPlayer : IPlayer
    {
        private Texture2D androidplayer;
        private Vector2 position;
        public int score = 0;
        public int End_Game = 0;

        private Color color;

        public AndroidPlayer(Vector2 position, Color color)
        {
            this.position = position;
            this.color = color;
        }
        public int GetScore()
        {
            return score;
        }

        public int SetScore()
        {
            return score++;
        }

        public Vector2 GetPosition()
        {
            return position;
        }
        public void SetSprite(Texture2D androidplayer)
        {
            this.androidplayer = androidplayer;
        }

        public void Draw(SpriteBatch spriteBatch) //Method to draw the Player Block
        {
            spriteBatch.Draw(androidplayer, position, color);
        }
        public void Update(GameTime gametime)
        {

            TouchCollection touchCollection = TouchPanel.GetState();//gets the state of the touch inputs
            if (touchCollection.Count > 0)//just a loop
            {
                if (touchCollection[0].State == TouchLocationState.Moved)//if there is a press, call the method MoveTest (which is still a test)
                {
                    if (touchCollection[0].Position.Y > GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 && this.position.Y < GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 225)//not complete cause it doesn't move.
                    {
                        this.position.Y += 25;//move 10px to the right
                    }
                    if (touchCollection[0].Position.Y < GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 && this.position.Y > 0)
                    {
                        this.position.Y -= 25;
                    }
                }
            }
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

        public void SetSprite(Texture2D desktopplayer)
        {
            this.desktopplayer = desktopplayer;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(desktopplayer, position, color);
        }
        public void Update(GameTime gametime)
        {
            // TODO: Add your update logic here
            KeyboardState kbstate = Keyboard.GetState();
            if (kbstate.IsKeyDown(Keys.Left) == true && this.position.X > 0) //if the left key is pressed and the position isn't at the edge...
            {
                this.position.X -= 10; //move 10px to the left
            }

            if (kbstate.IsKeyDown(Keys.Right) == true && this.position.X + 666 < GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width)//if the right key is pressed and the position isn't at the edge...
            {
                this.position.X += 10; //move 10pc to the right
            }
        }
    }
}