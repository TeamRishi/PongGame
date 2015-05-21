using System;
using Pong.UI;

namespace Pong.Models.Abstracts
{
    /// <summary>
    /// Abstract class holding all objects X and Y.
    /// </summary>
    abstract class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected Position(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Overrides ToString to show objects x, y and type
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return string.Format("({0}, {1}) - {2}", this.X, this.Y, GetType().Name);
        }
    }
}
