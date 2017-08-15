using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;


using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace AnimatedSprites
{
    class Player
    {


        public Vector2 playerPosition;
        private float playerSpeed;
        private Textures playerTextures;
        private Point playerframeSize;
        private Point playercurrentFrame;
        private Texture2D currentTexture;

        private Input input = new Input();
        private Point sheetSize = new Point(8, 1); // number of columns and rows in the image. for now each files has only 8 columns and 1 rows of animation. 


        int timeSinceLastFrame = 0;
        int millisecondsPerFame = 50;

        public Player()
        {
            playerTextures = new Textures();
            playerPosition = Vector2.Zero;
            playerSpeed = 2;
            playercurrentFrame = new Point(0, 0);
            playerframeSize = new Point(51, 51);

        }
        /// <summary>
        /// load textures for the player and anything related to player
        /// </summary>
        /// <param name="content"></param>
        public void loadPlayer(ContentManager content)
        {
            playerTextures.loadTextures(content);
        }

        /// <summary>
        /// update Player movement
        /// </summary>
        /// <param name="content"></param>
        /// <param name="gameTime"></param>
        /// <param name="keyboard"></param>
        public void updatePlayer(ContentManager content, GameTime gameTime, KeyboardState keyboard, GameWindow window)
        {
            updateFrame(content, gameTime);
            inputUpdate(keyboard);
            playerScreenCollision(window);


        }

        /// <summary>
        /// Draw player and anything touch  or used by the player
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="graphicsDevice"></param>
        public void drawPlayer(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            //spriteBatch.Draw(currentTexture, new Vector2(graphicsDevice.Viewport.Width / 2 - playerframeSize.X / 2 + playerPosition.X, graphicsDevice.Viewport.Height / 2 - playerframeSize.Y / 2 + playerPosition.Y), new Rectangle(playercurrentFrame.X * playerframeSize.X, playercurrentFrame.Y * playerframeSize.Y, playerframeSize.X, playerframeSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(currentTexture, new Vector2(playerPosition.X , playerPosition.Y), new Rectangle((playercurrentFrame.X * playerframeSize.X), (playercurrentFrame.Y * playerframeSize.Y), playerframeSize.X, playerframeSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            Texture2D testrectangle = new Texture2D(graphicsDevice, 1, 1);
            testrectangle.SetData(new Color[] { Color.White });
            // test collision
           
            spriteBatch.Draw(testrectangle, new Vector2(playerPosition.X, playerPosition.Y+5), new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerframeSize.X - 20, playerframeSize.Y-5), Color.Yellow);


            spriteBatch.End();
        }

        /// <summary>
        /// Update the input to the player
        /// </summary>
        /// <param name="keyboard"></param>
        private void inputUpdate(KeyboardState keyboard)
        { 
           
            playerPosition = new Vector2(playerPosition.X + (input.getkeyboardState.X*playerSpeed), playerPosition.Y + ((input.getkeyboardState.Y)*playerSpeed));

            input.updatekeyboardState(keyboard);
        }
        
        /// <summary>
        /// Update the correct frame for each action of the player. 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="gameTime"></param>
        private void updateFrame(ContentManager content, GameTime gameTime)
        {
            /*change frame is only used for Animation.*/
            bool changeanimationFrame = false;
            
            /*player go right*/
            if (input.getkeyboardState.X >= 1)
            {
                currentTexture = playerTextures.getTextures[2];
                changeanimationFrame = true;
               
            }

            /*player go left */
            else if (input.getkeyboardState.X <= -1)
            {
                currentTexture = playerTextures.getTextures[1];
                changeanimationFrame = true;

            }
            
            /*player standing still*/
            if (input.getkeyboardState.X == 0)
            {
                /*load the first image in the files "Jump.tga"*/
                currentTexture = playerTextures.getTextures[0];
              
                /*make sure that the player facing the direction when standing still*/
                if (input.getpreviousKey == Keys.A)
                {
                    playercurrentFrame = new Point(1, 0); //frame: second column, first row (start from 0)
                }
                else if(input.getpreviousKey == Keys.D)
                {
                    playercurrentFrame = new Point(0, 0); //frame: first column, first row (start from 0) see "Jump.tga"
                }

            }
            /*player crouch*/
            if (input.getkeyboardState.Y == 1 )
            {
                changeanimationFrame = false;
                currentTexture = playerTextures.getTextures[0];

                /*make sure that when crouch, player don't slide*/
                input.getkeyboardState = Vector2.Zero;


                if (input.getpreviousKey == Keys.A)
                {
                    playercurrentFrame = new Point(3, 0); //frame: forth column, first row
                }
                else if (input.getpreviousKey == Keys.D)
                {
                    playercurrentFrame = new Point(2, 0); //frame: third column, first row
                }

                
            }          
            /*player jumps*/
            if (input.getkeyboardState.Y == -2)
            {
                changeanimationFrame = false;
                currentTexture = playerTextures.getTextures[0];

                /*when player jumps and moves forward*/
                if (input.getkeyboardState.X <= -1)
                {
                    input.getkeyboardState = new Vector2(-1, -1);
                    playercurrentFrame = new Point(5, 0); //frame: sixth column, first row
                }
                else if (input.getkeyboardState.X >= 1)
                {
                    input.getkeyboardState = new Vector2(1, -1);
                    playercurrentFrame = new Point(4, 0); //frame: fifth column, first row
                }
                else
                {

                    /*when player only jumps*/
                    if (input.getpreviousKey == Keys.A)
                    {
                        input.getkeyboardState = new Vector2(0, -1);
                        playercurrentFrame = new Point(5, 0); //frame: sixth column, first row
                    }
                    else if (input.getpreviousKey == Keys.D)
                    {
                        input.getkeyboardState = new Vector2(0, -1);
                        playercurrentFrame = new Point(4, 0); //frame: fifth column, first row
                    }
                }


            }
            /*player falls*/
            if (input.getkeyboardState.Y == 0 && playerPosition.Y <= 100)
            {
               // input.getkeyboardState = new Vector2(0, 1);
                changeanimationFrame = false;
                currentTexture = playerTextures.getTextures[0];


                /*when player falls forward*/
                if (input.getkeyboardState.X <= -1)
                {
                    input.getkeyboardState = new Vector2(-1, 1);
                    playercurrentFrame = new Point(7, 0); //frame: eight column, first row
                }
                else if (input.getkeyboardState.X >= 1)
                {
                    input.getkeyboardState = new Vector2(1, 1);
                    playercurrentFrame = new Point(6, 0); //frame: seventh column, first row
                }
                else
                {
                    /*when player only falls*/
                    if (input.getpreviousKey == Keys.A)
                    {
                        input.getkeyboardState = new Vector2(0, 1);
                        playercurrentFrame = new Point(7, 0); //frame: eight column, first row
                    }
                    else if (input.getpreviousKey == Keys.D)
                    {
                        input.getkeyboardState = new Vector2(0, 1);
                        playercurrentFrame = new Point(6, 0); //frame: seventh column, first row
                    }
                }
                
            }


            //changeframe make sure that when if there is a repeated animation, we can control the speed of the animation. 
            playerAnimationMovement(changeanimationFrame, gameTime);
           
        }

        /// <summary>
        /// Player animation movement (multiple frames for one movement such as walking)
        /// </summary>
        /// <param name="changeanimationFrame"></param>
        /// <param name="gameTime"></param>
        private void playerAnimationMovement(bool changeanimationFrame, GameTime gameTime)
        {
            if (changeanimationFrame)
            {
                timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > millisecondsPerFame)
                {
                    timeSinceLastFrame -= millisecondsPerFame;


                    ++playercurrentFrame.X;
                    if (playercurrentFrame.X >= sheetSize.X)
                    {
                        playercurrentFrame.X = 0;
                        ++playercurrentFrame.Y;
                        if (playercurrentFrame.Y >= sheetSize.Y)
                        {
                            playercurrentFrame.Y = 0;
                        }
                    }

                }
            }
        }

        //Calculate player colision with the window frame!
        private void playerScreenCollision(GameWindow window)
        {
            
            
            if (playerPosition.X < 0)
            {
                playerPosition.X = 0;
            }
            if (playerPosition.Y <0)
            {
                playerPosition.Y = 0;
            }
            if (playerPosition.X > window.ClientBounds.Width - playerframeSize.X)
            {
                playerPosition.X = window.ClientBounds.Width - playerframeSize.X;
            }
            if (playerPosition.Y > window.ClientBounds.Height - playerframeSize.Y)
            {
                playerPosition.Y = window.ClientBounds.Height - playerframeSize.Y;
            }
        }

    }
}
