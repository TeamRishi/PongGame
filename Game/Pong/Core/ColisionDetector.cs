using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        /// Detects collision events between the Paddle and the Ball.
        /// </summary>
        public static void CheckPaddleColision(Paddle paddle, Ball ball)
        {
            if (paddle.X == ball.X &&
                ball.Y >= paddle.Y &&
                ball.Y <= paddle.Y + Utility.PaddleHeight)
            {
                ball.Collision();
            }
        }

        public static int CheckLifeLoss(int lifes, Ball ball, Paddle paddle)
        {
            if (ball.X == paddle.LifeZone)
            {
                lifes--;
                Sounds.Beep();
            }

            return lifes;
        }
    }
}
