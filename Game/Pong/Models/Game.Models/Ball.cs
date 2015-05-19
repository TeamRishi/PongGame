using System;
using Pong.Models.Abstracts;
using Pong.Models.Contracts;
using Pong.UI;

namespace Pong.Models.Game.Models
{
    /// <summary>
    /// Game ball object.
    /// </summary>
    class Ball : Position, IMoveable
    {
        public Direction Direction { get; private set; }

        public Ball(int x = 0, int y = 0)
            : base(x, y)
        {
            Random rng = new Random();
            int rngDirection = rng.Next(1, 5);
            switch (rngDirection)
            {
                case 1:
                    this.Direction = Direction.UpLeft;
                    break;
                case 2:
                    this.Direction = Direction.UpRight;
                    break;
                case 3:
                    this.Direction = Direction.DownLeft;
                    break;
                case 4:
                    this.Direction = Direction.DownRight;
                    break;
            }
        }

        public void Update(int value, Direction direction)
        {
            if (IsInsideField(value))
            {
                MoveInDirection(value, direction);
            }
            else
            {
                ChangeDirection(this.Direction);
                MoveInDirection(value, this.Direction);
            }

        }

        /// <summary>
        /// If ball has collided with an other object change its direction.
        /// </summary>
        public void Collision()
        {
            switch (this.Direction)
            {
                case Direction.UpLeft:
                    this.Direction = Direction.UpRight;
                    break;
                case Direction.UpRight:
                    this.Direction = Direction.UpLeft;
                    break;
                case Direction.DownLeft:
                    this.Direction = Direction.DownRight;
                    break;
                case Direction.DownRight:
                    this.Direction = Direction.DownLeft;
                    break;
            }

            MoveInDirection(Utility.BallSpeed, this.Direction);
        }

        /// <summary>
        /// Movement of the ball.
        /// </summary>
        /// <param name="value">Ball speed</param>
        /// <param name="direction">Ball direction</param>
        private void MoveInDirection(int value, Direction direction)
        {
            switch (direction)
            {
                case Direction.UpLeft:
                    this.X -= value;
                    this.Y -= value;
                    break;
                case Direction.UpRight:
                    this.X += value;
                    this.Y -= value;
                    break;
                case Direction.DownLeft:
                    this.X -= value;
                    this.Y += value;
                    break;
                case Direction.DownRight:
                    this.X += value;
                    this.Y += value;
                    break;
            }
        }

        private bool IsInsideField(int value)
        {
            if (this.X + value > Utility.PlaygoundWidth - 1 ||
                this.X - value < 0 ||
                this.Y + value > Utility.PlaygoundHeight - 1 ||
                this.Y - value < 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the ball has reached the end of the field and changes its movement.
        /// </summary>
        private void ChangeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.UpLeft:
                    if (this.X < 1)
                    {
                        this.Direction = Direction.UpRight;
                    }
                    else
                    {
                        this.Direction = Direction.DownLeft;
                    }

                    break;
                case Direction.UpRight:
                    if (this.Y < 1)
                    {
                        this.Direction = Direction.DownRight;
                    }
                    else
                    {
                        this.Direction = Direction.UpLeft;
                    }

                    break;
                case Direction.DownLeft:
                    if (this.X < 1)
                    {
                        this.Direction = Direction.DownRight;
                    }
                    else
                    {
                        this.Direction = Direction.UpLeft;
                    }

                    break;
                case Direction.DownRight:
                    if (this.X > Utility.PlaygoundWidth - 2)
                    {
                        this.Direction = Direction.DownLeft;
                    }
                    else
                    {
                        this.Direction = Direction.UpRight;
                    }

                    break;
            }
        }
    }
}
