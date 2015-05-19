using System;
using Pong.Models.Abstracts;
using Pong.Models.Contracts;
using Pong.UI;

namespace Pong.Models.Game.Models
{
    /// <summary>
    /// Game Paddle object.
    /// </summary>
    //TODO: Update summary.
    class Paddle : Position, IMoveable
    {   
        public Paddle(int x = 0, int y = 0) : base(x, y)
        {
        }

        public void UpdateY(int value)
        {
            if (IsValidY(this.Y + value))
            {
                this.Y += value;
            }
        }

        /// <summary>
        /// Validates y if is valid move.
        /// </summary>
        /// <param name="pos">y</param>
        /// <returns>bool</returns>
        private bool IsValidY(int pos)
        {
            if (pos >= 0 && pos <= Utility.PlaygoundHeight - Utility.PaddleHeight)
            {
                return true;
            }

            return false;
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
