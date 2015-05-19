using System;
using Pong.Models.Abstracts;
using Pong.Models.Contracts;

namespace Pong.Models.Game.Models
{
    class Ball: Position, IMoveable
    {
        public Ball(int x = 0, int y = 0) : base(x, y)
        {
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
