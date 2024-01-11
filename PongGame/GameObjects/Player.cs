using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGame.GameObjects.Structs;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame.GameObjects
{
    public class Player
    {
        public Texture2D playerTexture;
        public Coordinates position;
        public float movingSpeed;
        private int edgeBottomCollisionHeight, edgeCollisionWidth, playerBoxPositionX;
        private bool isSecondPlayer;

        // Colliders
        public System.Drawing.Rectangle collisionBox;
        public System.Drawing.Rectangle topCollider;
        public System.Drawing.Rectangle bottomCollider;

        public Player(float x, float y, int boxSizeX, int boxSizeY, bool isSecondPlayer)
        {
            this.position = new Coordinates(x, y);
            edgeBottomCollisionHeight = boxSizeY - 80;
            edgeCollisionWidth = boxSizeX / 4;
            playerBoxPositionX = boxSizeX - 10;
            this.isSecondPlayer = isSecondPlayer;
            
            if(!this.isSecondPlayer)
            {
                collisionBox = new System.Drawing.Rectangle((int)position.X + 5, (int)position.Y, boxSizeX, boxSizeY);
                topCollider = new System.Drawing.Rectangle((int)position.X + edgeCollisionWidth * 2 + 10, (int)position.Y, 50, 50);
                bottomCollider = new System.Drawing.Rectangle((int)position.X + edgeCollisionWidth * 2 + 10, (int)position.Y + edgeBottomCollisionHeight, 50, 80);
            }
            else
            {
                collisionBox = new System.Drawing.Rectangle((int)position.X + playerBoxPositionX, (int)position.Y, boxSizeX, boxSizeY);
                topCollider = new System.Drawing.Rectangle((int)position.X + edgeCollisionWidth * 2 + 40, (int)position.Y, 50, 50);
                bottomCollider = new System.Drawing.Rectangle((int)position.X + edgeCollisionWidth * 2 + 40, (int)position.Y + edgeBottomCollisionHeight, 50, 80);
            }
            
            movingSpeed = 8;
        }

        public void MoveUp()
        {
            if(position.Y > 10)
                position.Y -= movingSpeed;


            if (!isSecondPlayer)
            {
                collisionBox.Location = new System.Drawing.Point((int)position.X + 5, (int)position.Y);
                topCollider.Location = new System.Drawing.Point((int)position.X + edgeCollisionWidth * 2 + 10, (int)position.Y);
                bottomCollider.Location = new System.Drawing.Point((int)position.X + edgeCollisionWidth * 2 + 10, (int)position.Y + edgeBottomCollisionHeight);
            }
            else
            {
                collisionBox.Location = new System.Drawing.Point((int)position.X + playerBoxPositionX, (int)position.Y);
                topCollider.Location = new System.Drawing.Point((int)position.X + edgeCollisionWidth * 2 + 40, (int)position.Y);
                bottomCollider.Location = new System.Drawing.Point((int)position.X + edgeCollisionWidth * 2 + 40, (int)position.Y + edgeBottomCollisionHeight);
            }
            
        }
        public void MoveDown()
        {
            if(position.Y < Game1.screenHeight - 450 - 10)
                position.Y += movingSpeed;

            if (!isSecondPlayer)
            {
                collisionBox.Location = new System.Drawing.Point((int)position.X + 5, (int)position.Y);
                topCollider.Location = new System.Drawing.Point((int)position.X + edgeCollisionWidth * 2 + 10, (int)position.Y);
                bottomCollider.Location = new System.Drawing.Point((int)position.X + edgeCollisionWidth * 2 + 10, (int)position.Y + edgeBottomCollisionHeight);
            }
            else
            {
                collisionBox.Location = new System.Drawing.Point((int)position.X + playerBoxPositionX, (int)position.Y);
                topCollider.Location = new System.Drawing.Point((int)position.X + edgeCollisionWidth * 2 + 40, (int)position.Y);
                bottomCollider.Location = new System.Drawing.Point((int)position.X + edgeCollisionWidth * 2 + 40, (int)position.Y + edgeBottomCollisionHeight);
            }
        }
    }
}
