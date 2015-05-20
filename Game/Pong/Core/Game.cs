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
            int lifes = Utility.Lifes;

            while (lifes > 0)
            {
                Utility.SetField();

                Draw.Clear();
                Draw.DrawPaddle(leftPaddle);
                Draw.DrawBall(gameBall);
                Draw.DrawLifes(lifes);
                Draw.DrawDebug(gameBall, leftPaddle);

                Direction pressedKey = InputHandler.PressedKey();
                if (pressedKey != Direction.Null)
                {
                    leftPaddle.Update(Utility.PaddleSpeed, pressedKey);
                }

                gameBall.Update(Utility.BallSpeed, gameBall.Direction);
                ColisionDetector.CheckPaddleColision(leftPaddle, gameBall);
                lifes = ColisionDetector.CheckLifeLoss(lifes, gameBall);
            }

            Draw.GameOver();
        }
    }
}
