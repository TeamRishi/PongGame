using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Models.Abstracts
{
    /// <summary>
    /// Abstract class holding all objects X and Y.
    /// </summary>
    abstract class Position
    {
        private int x;
        private int y;

        protected int X
        {
            get { return this.x; }
            set
            {
                if (IsValidPos(value))
                {
                    this.x = value;
                }
            }
        }

        protected int Y
        {
            get { return this.y; }
            set
            {
                if (IsValidPos(value))
                {
                    this.y = value;
                }
            }
        }

        protected Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Validates x or y.
        /// </summary>
        /// <param name="pos">x or y</param>
        /// <returns>true if can be set or exception</returns>
        private bool IsValidPos(int pos)
        {
            //TODO: Fix magic num 40 to const in UI.Utility.Const.
            //TODO: Add an other Method for y.
            if (pos >= 0 && pos <= 40)
            {
                return true;
            }

            throw new ArgumentException("Invalid position!");
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
