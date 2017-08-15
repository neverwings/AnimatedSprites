using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace AnimatedSprites
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameWorld world;

        Point frameSize = new Point(51, 51);
        Point currentFrame = new Point(0, 0);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
        
            world = new GameWorld();
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
            world.loadWord(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            // TODO: Add your update logic here
           
            KeyboardState keyboard = Keyboard.GetState();
            world.updateWorld(Content, gameTime, keyboard, Window);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            world.drawWord(spriteBatch, GraphicsDevice);
         

            base.Draw(gameTime);
        }
    }
}






//        GraphicsDeviceManager graphics;
//        SpriteBatch spriteBatch;

//        //Texture2D textureRunLeft;
//        //Texture2D textureRunRight;
//        //Texture2D textureIdle;
//        //Texture2D textureJump;
//        //Texture2D textureDraw;
//        Texture2D rectangleTestTexture;

//        Point frameSize = new Point(51, 51);
//        Point currentFrame = new Point(0, 0);
//        Point sheetSize = new Point(8, 1);
//        Vector2 characterPos = new Vector2(0, 0);


//        int timeSinceLastFrame = 0;
//        int millisecondsPerFame = 50;
//        int maximumJumpHeight = 50;
//        bool falldown = false;
//        float characterSpeed = 5f;


//        Player player = new Player();

//        Keys previousKey = Keys.None;

//        public Game1()
//        {
//            graphics = new GraphicsDeviceManager(this);
//            Content.RootDirectory = "Content";
//            //TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 80); // change the whole game framerate NOT IDEAL!!!
//        }

//        /// <summary>
//        /// Allows the game to perform any initialization it needs to before starting to run.
//        /// This is where it can query for any required services and load any non-graphic
//        /// related content.  Calling base.Initialize will enumerate through any components
//        /// and initialize them as well.
//        /// </summary>
//        protected override void Initialize()
//        {
//            // TODO: Add your initialization logic here

//            base.Initialize();
//        }

//        /// <summary>
//        /// LoadContent will be called once per game and is the place to load
//        /// all of your content.
//        /// </summary>
//        protected override void LoadContent()
//        {
//            // Create a new SpriteBatch, which can be used to draw textures.
//            spriteBatch = new SpriteBatch(GraphicsDevice);

//            // TODO: use this.Content to load your game content here
//            //textureRunLeft = Content.Load<Texture2D>(@"Images\run_left");
//            //textureRunRight = Content.Load<Texture2D>(@"Images\run_right");
//            //textureIdle = Content.Load<Texture2D>(@"Images\Jump");

//            rectangleTestTexture = new Texture2D(GraphicsDevice, 1 , 1);
//            rectangleTestTexture.SetData(new Color[] { Color.White });
//        }

//        /// <summary>
//        /// UnloadContent will be called once per game and is the place to unload
//        /// all content.
//        /// </summary>
//        protected override void UnloadContent()
//        {
//            // TODO: Unload any non ContentManager content here
//        }

//        /// <summary>
//        /// Allows the game to run logic such as updating the world,
//        /// checking for collisions, gathering input, and playing audio.
//        /// </summary>
//        /// <param name="gameTime">Provides a snapshot of timing values.</param>
//        protected override void Update(GameTime gameTime)
//        {
//            KeyboardState keyboardState = Keyboard.GetState();
//            // Allows the game to exit
//            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
//            //    this.Exit();

//            //bool changeFrame = false;

//            //// TODO: Add your update logic here
//            //if (keyboardState.IsKeyDown(Keys.Left))
//            //{
//            //    textureDraw = textureRunLeft;
//            //    changeFrame = true;
//            //    previousKey = Keys.Left;
//            //}
//            //if (keyboardState.IsKeyDown(Keys.Right))
//            //{
//            //    textureDraw = textureRunRight;
//            //    changeFrame = true;
//            //    previousKey = Keys.Right;
//            //}
//            //if (keyboardState.IsKeyDown(Keys.Down))
//            //{
//            //    textureDraw = textureIdle;
//            //    changeFrame = false;

//            //    if (currentFrame == new Point(0,0)  || currentFrame == new Point(4, 0) || currentFrame == new Point(6, 0))

//            //    //if (previousKey == Keys.Left || currentFrame == new Point(0,0))
//            //    {
//            //        currentFrame = new Point(2, 0);
//            //    }
//            //    //else if (previousKey == Keys.Right)
//            //    else if (currentFrame == new Point(1, 0)  || currentFrame == new Point(5, 0) || currentFrame == new Point(7, 0))

//            //    {
//            //        currentFrame = new Point(3, 0);
//            //    }
//            //}
//            //if (keyboardState.IsKeyDown(Keys.Up))
//            //{
//            //    textureDraw = textureIdle;
//            //    changeFrame = false;
//            //    if (previousKey == Keys.Left)
//            //    {
//            //        currentFrame = new Point(5, 0);
//            //        if( characterPos.Y <= maximumJumpHeight && falldown == false)
//            //        {
//            //            ++characterPos.Y;
//            //        }
//            //        if ( characterPos.Y >= maximumJumpHeight)
//            //        {
//            //            falldown = true;

//            //            --characterPos.Y;
//            //            if (characterPos.Y == 0)
//            //            {
//            //                falldown = false;
//            //            }
//            //        }
//            //    }
//            //    else if (previousKey == Keys.Right)
//            //    {

//            //        if (characterPos.Y <= maximumJumpHeight)
//            //        {
//            //            currentFrame = new Point(4, 0);
//            //            ++characterPos.Y;
//            //        }
//            //        else
//            //        {
//            //            --characterPos.Y;
//            //        }
//            //    }
//            //}
//            //else
//            //{
//            //    textureDraw = textureIdle;
//            //    changeFrame = false;
//            //    if (previousKey == Keys.Left)
//            //    {
//            //        currentFrame = new Point(1, 0);
//            //    }
//            //    else if( previousKey == Keys.Right)
//            //    {
//            //        currentFrame = new Point(0, 0);
//            //    }
//            //}


//            //if (changeFrame)
//            //{
//            //    timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
//            //    if (timeSinceLastFrame > millisecondsPerFame)
//            //    {
//            //        timeSinceLastFrame -= millisecondsPerFame;


//            //        ++currentFrame.X;
//            //        if (currentFrame.X >= sheetSize.X)
//            //        {
//            //            currentFrame.X = 0;
//            //            ++currentFrame.Y;
//            //            if (currentFrame.Y >= sheetSize.Y)
//            //            {
//            //                currentFrame.Y = 0;
//            //            }
//            //        }


//            //        // timeSinceLastFrame = 0;
//            //    }
//            //}
//            base.Update(gameTime);
//        }

//        /// <summary>
//        /// This is called when the game should draw itself.
//        /// </summary>
//        /// <param name="gameTime">Provides a snapshot of timing values.</param>
//        protected override void Draw(GameTime gameTime)
//        {
//            GraphicsDevice.Clear(Color.CornflowerBlue);

//            // TODO: Add your drawing code here
//            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

//            spriteBatch.Draw(player.draw(Content), new Vector2(GraphicsDevice.Viewport.Width/2 - frameSize.X/2 + player.playerPosition.X, GraphicsDevice.Viewport.Height/2 - frameSize.Y/2 + player.playerPosition.Y), new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
//            spriteBatch.Draw(rectangleTestTexture, new Rectangle(10,10, GraphicsDevice.Viewport.Width - 20, GraphicsDevice.Viewport.Height- 20), Color.Green);
//            spriteBatch.End();

//            base.Draw(gameTime);
//        }
//    }
//}
