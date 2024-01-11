using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace PongGame.GameObjects
{
    public class ButtonBase
    {
        static MouseState currentMouseState;
        static MouseState previousMouseState;

        public ButtonBase()
        {

        }

        public static MouseState GetState()
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            return currentMouseState;
        }

        public static bool IsPressed(bool left)
        {
            if(left)
                return currentMouseState.LeftButton == ButtonState.Pressed;
            else
                return currentMouseState.RightButton == ButtonState.Pressed;
        }

        public static bool HasNotBeenPressd(bool left)
        {
            if (left)
                return currentMouseState.LeftButton == ButtonState.Pressed && !(previousMouseState.LeftButton == ButtonState.Pressed);
            else
                return currentMouseState.RightButton == ButtonState.Pressed && !(previousMouseState.RightButton == ButtonState.Pressed);

        }
    }
}
