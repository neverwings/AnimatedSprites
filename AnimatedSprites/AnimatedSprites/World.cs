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
        public void updateWorld(ContentManager content, GameTime gameTime, KeyboardState keyboard)
        {
            player.updatePlayer(content, gameTime, keyboard);
        }

        //Draw world
        public void drawWord(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
          player.drawPlayer(spriteBatch, graphicsDevice);
        }


        
        
        
    }
}
