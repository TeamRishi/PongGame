using System;
using Pong.Models.Abstracts;
using Pong.Models.Game.Models;
using Pong.UI;

namespace Pong.Core
{
    class Game
    {
        public static void Main()
        {
            Paddle leftPaddle = new Paddle(Utility.LeftPaddleX, Utility.LeftPaddleY);
            Ball gameBall = new Ball(Utility.BallX, Utility.BallY);
            int lives = Utility.Lifes;

            while (lives > 0)
            {
                Utility.SetField();

                Draw.Clear();
                //Draw.DrawScore();
                Draw.DrawPaddle(leftPaddle);
                Draw.DrawBall(gameBall);
                Draw.DrawDebug(gameBall, leftPaddle);

                Direction pressedKey = InputHandler.PressedKey();
                if (pressedKey != Direction.Null)
                {
                    leftPaddle.Update(Utility.PaddleSpeed, pressedKey);
                }

                gameBall.Update(Utility.BallSpeed, gameBall.Direction);
                ColisionDetector.CheckLeftPaddleColisions(leftPaddle, gameBall);

                // TODO: Add in ColitionDetection lives loss.
            }

            // TODO: Add GameOver event in UI.
        }
    }
}
