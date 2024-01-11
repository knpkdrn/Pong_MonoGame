using Microsoft.Xna.Framework.Input;
using PongGame.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame.Managers
{
    public static class KeyboardManager
    {

        public static bool CheckForRestart()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                return true;
            }

            return false;
        }

        public static void CheckForInput(Player playerOne, Player playerTwo)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.W))
            {
                playerOne.MoveUp();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                playerOne.MoveDown();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                playerTwo.MoveUp();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                playerTwo.MoveDown();
            }

            if(Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                playerOne.position = new GameObjects.Structs.Coordinates(0, 0);
                playerTwo.position = new GameObjects.Structs.Coordinates(0, 0);
            }
        }
    }
}
