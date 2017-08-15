using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Collision.Shapes;

namespace AnimatedSprites
{
    class GameWorld 
    {
        //load world

        private Player player;
        
        private World physicsWorld;
       
        

        public GameWorld()
        {
            player = new Player();
            physicsWorld = new World(new Vector2(0f,9.82f));
            
        }

        //Initialize world
        public void loadWord(ContentManager content)
        {
           
            player.loadPlayer(content);

          
        }

        //update world
        public void updateWorld(ContentManager content, GameTime gameTime, KeyboardState keyboard, GameWindow window)
        {
            //physicsWorld.Step(0.03333f);
            player.updatePlayer(content, gameTime, keyboard, window);
        }

        //Draw world
        public void drawWord(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
           

            // create a random rectangle to make sure that player have collision detection 

            Texture2D testrectangle = new Texture2D(graphicsDevice, 1, 1);
            testrectangle.SetData(new Color[] { Color.White });

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            spriteBatch.Draw(testrectangle, new Rectangle(10, 10, graphicsDevice.Viewport.Width - 20, graphicsDevice.Viewport.Height - 20), Color.Green);

            spriteBatch.End();

            // make sure that player is drawn after to have the player on top
            player.drawPlayer(spriteBatch, graphicsDevice);
        }

        public bool MyOnCollision(Fixture f1, Fixture f2, Contact contact)

        {

         //We want the collision to happen, so we return true.

         return true;

        } 

        
        
        
    }
}
