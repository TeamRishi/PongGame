using Pong.Models.Abstracts;

namespace Pong.Models.Contracts
{
    interface IMoveable
    {
        /// <summary>
        /// Update the objects position.
        /// </summary>
        /// <param name="value">Rate of movement</param>
        /// <param name="direction">Direction of movement</param>
        void Update(int value, Direction direction);
    }
}
