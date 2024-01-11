using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame.Managers
{
    public static class XnaConverter
    {
        public static Microsoft.Xna.Framework.Rectangle ConvertSystemDrawingToXnaRectangle(System.Drawing.Rectangle rectangle)
        {
            return new Microsoft.Xna.Framework.Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }
    }
}
