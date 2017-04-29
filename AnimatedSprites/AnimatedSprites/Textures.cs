using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace AnimatedSprites
{
    class Textures
    {
        private List<Texture2D> playerTexture;
        private Point playerframeSize;
        public Textures()
        {
            playerTexture = new List<Texture2D>();
            playerframeSize = new Point(51, 51);
            
        }
        public Point getplayerFrameSize
        {
            get
            {
                return playerframeSize;
            }
        }
        public List<Texture2D> getTextures
        {
            get
            {
                /*big trouble if playerTexture count = 0*/
                return playerTexture;
            }
        }
        public void loadTextures(ContentManager content)
        {

            //Basic of player movements. 
            playerTexture.Add(content.Load<Texture2D>(@"Images\Jump"));
            playerTexture.Add(content.Load<Texture2D>(@"Images\run_left"));
            playerTexture.Add(content.Load<Texture2D>(@"Images\run_right"));
            
        }
    }
}
