using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimatedSprites
{
    class World
    {
        //load world

        Player player;

        public World()
        {
            player = new Player();
        }

        //Initialize world
        public void loadWord(ContentManager content)
        {
            player.loadPlayer(content);
           
        }

        //update world
        public void updateWorld(ContentManager content, GameTime gameTime, KeyboardState keyboard, GameWindow window)
        {
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


        
        
        
    }
}
