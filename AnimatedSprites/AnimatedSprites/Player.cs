﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace AnimatedSprites
{
    class Player
    {


        public Vector2 playerPosition;
        float playerSpeed;
        Textures playerTextures;
        Point playercurrentFrame;
        Texture2D currentTexture;

        Input input = new Input();
        Point sheetSize = new Point(8, 1); // number of columns and rows in the image. for now each files has only 8 columns and 1 rows of animation. 


        int timeSinceLastFrame = 0;
        int millisecondsPerFame = 50;

        public Player()
        {
            playerTextures = new Textures();
            playerPosition = Vector2.Zero;
            playerSpeed = 2;
            playercurrentFrame = new Point(0, 0);
            
        }

        public void loadPlayer(ContentManager content)
        {
            playerTextures.loadTextures(content);
        }


        public void updatePlayer(ContentManager content, GameTime gameTime, KeyboardState keyboard)
        {
            updateFrame(content, gameTime);
            inputUpdate(keyboard);
            
        }

        public void drawPlayer(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            spriteBatch.Draw(currentTexture, new Vector2(graphicsDevice.Viewport.Width / 2 - playerTextures.getplayerFrameSize.X / 2 + playerPosition.X, graphicsDevice.Viewport.Height / 2 - playerTextures.getplayerFrameSize.Y / 2 + playerPosition.Y), new Rectangle(playercurrentFrame.X * playerTextures.getplayerFrameSize.X, playercurrentFrame.Y * playerTextures.getplayerFrameSize.Y, playerTextures.getplayerFrameSize.X, playerTextures.getplayerFrameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            spriteBatch.End();
        }

        private void inputUpdate(KeyboardState keyboard)
        { 
           
            playerPosition = new Vector2(playerPosition.X + (input.getkeyboardState.X*playerSpeed), playerPosition.Y + ((input.getkeyboardState.Y)*playerSpeed));

            input.updatekeyboardState(keyboard);
        }
        
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
            Debug.WriteLine(input.getkeyboardState.Y);
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
                    playercurrentFrame = new Point(5, 0); //frame: sixth column, first row
                }
                else if (input.getkeyboardState.X >= 1)
                {
                    input.getkeyboardState = new Vector2(1, 1);
                    playercurrentFrame = new Point(4, 0); //frame: fifth column, first row
                }
                else
                {
                    /*when player only falls*/
                    if (input.getpreviousKey == Keys.A)
                    {
                        input.getkeyboardState = new Vector2(0, 1);
                        playercurrentFrame = new Point(5, 0); //frame: sixth column, first row
                    }
                    else if (input.getpreviousKey == Keys.D)
                    {
                        input.getkeyboardState = new Vector2(0, 1);
                        playercurrentFrame = new Point(4, 0); //frame: fifth column, first row
                    }
                }
                
            }


            //changeframe make sure that when if there is a repeated animation, we can control the speed of the animation. 
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





    }
}