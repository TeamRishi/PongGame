using System;
using Pong.Models.Abstracts;
using Pong.Models.Contracts;
using Pong.UI;

namespace Pong.Models.Game.Models
{
    /// <summary>
    /// Game Paddle object.
    /// </summary>
    class Paddle : Position, IMoveable
    {
        public int LifeZone { get; set; }

        public Paddle(int x, int y, int lifeZone)
            : base(x, y)
        {
            this.LifeZone = lifeZone;
        }

        /// <summary>
        /// Updates paddle position.
        /// </summary>
        /// <param name="value">Paddle speed</param>
        /// <param name="direction">Move direction</param>
        public void Update(int value, Direction direction)
        {
            if (direction == Direction.Up)
            {
                if (IsValidY(this.Y - value))
                {
                    this.Y--;
                }
            }

            if (direction == Direction.Down)
            {
                if (IsValidY(this.Y + value))
                {
                    this.Y++;
                }
            }
        }

        /// <summary>
        /// Validates y if is valid move.
        /// </summary>
        /// <param name="pos">y</param>
        /// <returns>bool</returns>
        private bool IsValidY(int pos)
        {
            int fieldEnd = Utility.PlaygoundHeight - Utility.PaddleHeight;
            if (pos >= 0 && pos <= fieldEnd)
            {
                return true;
            }

            return false;
        }
    }
}
