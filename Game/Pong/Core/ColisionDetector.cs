using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pong.Models.Game.Models;
using Pong.UI;

namespace Pong.Core
{
    /// <summary>
    /// Detects collision events.
    /// </summary>
    class ColisionDetector
    {
        /// <summary>
        /// Detects collision events between the leftPaddle and the ball.
        /// </summary>
        public static void CheckLeftPaddleColisions(Paddle leftPaddle, Ball ball)
        {
            if (leftPaddle.X == ball.X && 
                ball.Y >= leftPaddle.Y && 
                ball.Y <= leftPaddle.Y + Utility.PaddleHeight)
            {
                ball.Collision();
            }
        }
    }
}
