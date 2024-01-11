using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame.GameObjects.Structs
{
    public struct Coordinates
    {
        public float Y;
        public float X;

        public Coordinates(float x, float y)
        {
            X = Game1.screenWidth / 2 + x;
            Y = Game1.screenHeight / 2 + y;
        }
    }
}
