using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pong.Models.Abstracts;
using Pong.Models.Contracts;

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

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
