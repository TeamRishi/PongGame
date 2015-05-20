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

        public static int CheckLifeLoss(int lifes, Ball ball, string player)
        {
            if (ball.X == 0 && player == "PlayerLeft")
            {
                lifes--;
                ///<summary>
                ///Added beep effect 
                Thread beep = new Thread(Console.Beep);
                beep.Start();
                ///</summary>

            }
            else if (ball.X == 79 && player == "PlayerRight")
            {
                lifes--;
                ///<summary>
                ///Added beep effect 
                Thread beep = new Thread(Console.Beep);
                beep.Start();
                ///</summary>
            }

            return lifes;
        }

        internal static int CheckLifeLoss(int leftPaddlelifes, Ball gameBall)
        {
            throw new NotImplementedException();
        }
    }
}
