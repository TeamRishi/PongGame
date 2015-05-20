using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Models.Abstracts
{
    /// <summary>
    /// Directions of the objects in the game.
    /// </summary>
    enum Direction
    {
        LeftPaddleUp,
        LeftPaddleDown,
        RightPaddleUp,
        RightPaddleDown,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight,
        Null
    }
}
