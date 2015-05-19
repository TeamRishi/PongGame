using System;
using Pong.UI;

namespace Pong.Models.Abstracts
{
    /// <summary>
    /// Abstract class holding all objects X and Y.
    /// </summary>
    abstract class Position
    {
        private int x;
        private int y;

        public int X
        {
            get { return this.x; }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get { return this.y; }
            set
            {
                this.y = value;
            }
        }

        protected Position(int x, int y)
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
            return string.Format("({0}, {1}) - {2}", this.x, this.y, GetType().Name);
        }
    }
}
