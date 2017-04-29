using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace AnimatedSprites
{
    class Input
    {

        private Vector2 currentState;
        private Keys previousKey;


        public Keys getpreviousKey
        {
            get
            {
                return previousKey;
            }
        }
   
        public Input()
        {
            // keyboardState = Keyboard.GetState();
            currentState = Vector2.Zero;
            previousKey = Keys.D;
        }

        public Vector2 getkeyboardState
        {
            get
            {
                return currentState;
            }
            set
            {
                currentState = value;
            }
        }

        public void updatekeyboardState(KeyboardState keyboardState)
        {

          //  KeyboardState keyboardState = Keyboard.GetState();

          
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    currentState.X = -1;
                // player.movement(new Vector2(-1,0));
                    previousKey = Keys.A;
                   
                }
                
                else if (keyboardState.IsKeyDown(Keys.D))
                {
                    currentState.X = 1;
                    previousKey = Keys.D;
                }
                else if(!keyboardState.IsKeyDown(Keys.D) || !keyboardState.IsKeyDown(Keys.A))
                {
                    currentState.X = 0;
                }

                if (keyboardState.IsKeyDown(Keys.W))
                {
                    currentState.Y = -2;
                   
                }
                else if (keyboardState.IsKeyDown(Keys.S))
                {
                    currentState.Y = 1;

                }
                else if (!keyboardState.IsKeyDown(Keys.W)|| !keyboardState.IsKeyDown(Keys.S))
                {
                    currentState.Y = 0;
                }

              


        }
        

    }
}
