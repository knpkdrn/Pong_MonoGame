using Microsoft.Xna.Framework.Graphics;
using PongGame.GameObjects.Enums;
using PongGame.GameObjects.Structs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame.GameObjects
{
    public class Ball
    {
        public Texture2D ballTexture;
        public Coordinates position;
        public Directions direction;
        public Rectangle collisionBox;
        private float _movingSpeed;

        public Ball(float x, float y, int boxSizeX, int boxSizeY)
        {
            position = new Coordinates(x, y);
            collisionBox = new Rectangle((int)position.X, (int)position.Y, boxSizeX, boxSizeY);
            direction = Directions.Left;
            _movingSpeed = 10;
        }

        public Ball(float x, float y, int boxSizeX, int boxSizeY, Texture2D texture)
        {
            position = new Coordinates(x, y);
            collisionBox = new Rectangle((int)position.X, (int)position.Y, boxSizeX, boxSizeY);
            direction = Directions.Left;
            _movingSpeed = 10;
            ballTexture = texture;
        }

        public void CheckCollision(Player playerOne, Player playerTwo, Rectangle playingField)
        {
            if (collisionBox.IntersectsWith(playerOne.topCollider) || (!playingField.Contains(collisionBox.Location) && this.direction == Directions.BottomRight))
            {
                this.direction = Directions.TopRight;
            }
            else if (collisionBox.IntersectsWith(playerOne.bottomCollider) || (!playingField.Contains(collisionBox.Location) && this.direction == Directions.TopRight))
            {
                this.direction = Directions.BottomRight;
            }
            else if (collisionBox.IntersectsWith(playerTwo.topCollider) || (!playingField.Contains(collisionBox.Location) && this.direction == Directions.BottomLeft))
            {
                this.direction = Directions.TopLeft;
            }
            else if (collisionBox.IntersectsWith(playerTwo.bottomCollider) || (!playingField.Contains(collisionBox.Location) && this.direction == Directions.TopLeft))
            {
                this.direction = Directions.BottomLeft;
            }
            else if (collisionBox.IntersectsWith(playerOne.collisionBox) && !collisionBox.IntersectsWith(playerOne.topCollider) && !collisionBox.IntersectsWith(playerOne.bottomCollider))
            {
                this.direction = Directions.Right;
            }
            else if (collisionBox.IntersectsWith(playerTwo.collisionBox) && !collisionBox.IntersectsWith(playerTwo.topCollider) && !collisionBox.IntersectsWith(playerTwo.bottomCollider))
            {
                this.direction = Directions.Left;
            }
        }
        public void Move() 
        { 
            if(direction.Equals(Directions.Left))
            {
                MoveLeft();
            }
            else if(direction.Equals(Directions.Right))
            {
                MoveRight();
            }
            else if (direction.Equals(Directions.BottomLeft))
            {
                MoveDown();
                MoveLeft();
            }
            else if(direction.Equals(Directions.TopLeft))
            {
                MoveUp();
                MoveLeft();
            }
            else if(direction.Equals(Directions.BottomRight))
            {
                MoveDown();
                MoveRight();
            }
            else if (direction.Equals(Directions.TopRight))
            {
                MoveUp();
                MoveRight();
            }
        }
        public void MoveUp()
        {
            position.Y -= _movingSpeed;
            collisionBox.Location = new Point((int)position.X, (int)position.Y);
        }
        public void MoveDown()
        {
            position.Y += _movingSpeed;
            collisionBox.Location = new Point((int)position.X, (int)position.Y);
        }
        public void MoveLeft()
        {
            position.X -= _movingSpeed;
            collisionBox.Location = new Point((int)position.X, (int)position.Y);
        }
        public void MoveRight()
        {
            position.X += _movingSpeed;
            collisionBox.Location = new Point((int)position.X, (int)position.Y);
        }
    }
}
