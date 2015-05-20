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
            Paddle rightPaddle = new Paddle(Utility.RightPaddleX,Utility.RightPaddleY);
            Ball gameBall = new Ball(Utility.BallX, Utility.BallY);
            int leftPaddlelifes = Utility.Lifes;
            int rightPaddlelifes = Utility.Lifes;
            Sounds.PlayingSounds("background");

            while (leftPaddlelifes > 0 && rightPaddlelifes > 0)
            {
                Utility.SetField();
                Draw.Clear();
                Draw.DrawPaddle(leftPaddle);
                Draw.DrawPaddle(rightPaddle);
                Draw.DrawBall(gameBall);
                Draw.DrawLifes(leftPaddlelifes, rightPaddlelifes);
                Draw.DrawDebug(gameBall, leftPaddle);

                Direction pressedKey = InputHandler.PressedKey();

                switch (pressedKey)
                {
                    case Direction.LeftPaddleUp:
                    case Direction.LeftPaddleDown:
                        leftPaddle.Update(Utility.PaddleSpeed, pressedKey);
                        break;
                    case Direction.RightPaddleUp:
                    case Direction.RightPaddleDown:
                        rightPaddle.Update(Utility.PaddleSpeed, pressedKey);
                        break;
                }
               
                gameBall.Update(Utility.BallSpeed, gameBall.Direction);
                ColisionDetector.CheckPaddleColision(leftPaddle, gameBall);
                ColisionDetector.CheckPaddleColision(rightPaddle, gameBall);
                leftPaddlelifes = ColisionDetector.CheckLifeLoss(leftPaddlelifes, gameBall, "PlayerLeft");
                rightPaddlelifes = ColisionDetector.CheckLifeLoss(rightPaddlelifes, gameBall, "PlayerRight");
            }

            Draw.GameOver(leftPaddlelifes,rightPaddlelifes);
            Sounds.PlayingSounds("gameover");
        }
    }
}
