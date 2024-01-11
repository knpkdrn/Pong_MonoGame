using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PongGame.GameObjects
{
    public class Button
    {
        private Texture2D _staticTexture;
        private Texture2D _clickedTexture;

        public int AnimationTime { get; set; }
        public string Name { get; set; }
        public Point Dimensions { get; set; }
        public int Id { get; set; }
        public float LayerDepth { get; set; }
        public bool Visible { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public int CellWidth { get; set; }
        public int CellHeight { get; set; }


        public Button(Texture2D staticImage, Texture2D clickedImage, Point dimensions, Vector2 position, string name, int id, bool visible, float layerDepth)
        {
            _clickedTexture = clickedImage;
            _staticTexture = staticImage;

            Texture = _staticTexture;
            CellWidth = dimensions.X; 
            CellHeight = dimensions.Y;
            LayerDepth = layerDepth;
            Visible = visible;
            AnimationTime = 0;
            Name = name;
            Id = id;
            Position = position;
            Dimensions = new Point(dimensions.X, dimensions.Y);
        }

        public void Clicked()
        {
            AnimationTime = 30;
            Texture = _clickedTexture;
        }

        public void UpdateButton()
        {
            if (AnimationTime > 0)
                AnimationTime--;

            if (AnimationTime == 0)
                Texture = _clickedTexture;
        }


    }
}
