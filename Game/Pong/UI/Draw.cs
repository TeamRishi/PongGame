using System;
using Pong.Models.Game.Models;

namespace Pong.UI
{
    class Draw
    {
        public static void Clear()
        {
            Console.Clear();
        }

        public static void DrawPaddle(Paddle paddle)
        {
            for (int i = 0; i < Utility.PaddleHeight; i++)
            {
                Console.SetCursorPosition(paddle.X, paddle.Y + i);
                Console.Write(Utility.PaddleChar);
            }
        }

        public static void DrawBall(Ball ball)
        {
            try
            {
                Console.SetCursorPosition(ball.X, ball.Y);
                Console.Write(Utility.BallChar);
            }
            catch (ArgumentOutOfRangeException)
            {
                // Failsafe in case ball goes in the corner of the field.
                ball.X = Utility.BallX;
                ball.Y = Utility.BallY;
            }
        }

        // TODO: Implement score and fix here!
        public static void DrawScore()
        {
            Console.SetCursorPosition(0, Utility.PlaygoundHeight - 1);
            Console.Write("Score: ");
        }

        public static void DrawLifes(int LeftPaddlelifes, int RightPaddleLifes)
        {
            Console.SetCursorPosition(25, Utility.PlaygoundHeight - 1);
            Console.Write("Player Left: {0} : {1} Player Right", LeftPaddlelifes, RightPaddleLifes);
        }

        public static void GameOver(int LeftPaddleLifes, int RightPaddleLifes)
        {
            Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            string gameOver = "GAME OVER";
            string LeftPlayerWinns = "Left Player  winns!";
            string RightPlayerWinns = "Right Player  winns!";
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - gameOver.Length / 2,
                Utility.PlaygoundHeight / 2);
            Console.WriteLine(gameOver);
            if (LeftPaddleLifes > RightPaddleLifes)
            {
                Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - LeftPlayerWinns.Length / 2,
                Utility.PlaygoundHeight / 2 + 1);
                Console.WriteLine(LeftPlayerWinns);
            }
            if (LeftPaddleLifes < RightPaddleLifes)
            {
                Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - RightPlayerWinns.Length / 2,
                Utility.PlaygoundHeight / 2 + 1);
                Console.WriteLine(RightPlayerWinns);
            }
        }

        public static void DrawDebug(Ball ball, Paddle paddle)
        {
            Console.SetCursorPosition(Utility.PaddleHeight, Utility.PlaygoundHeight - 2);
            Console.Write(ball.Direction + " " + paddle + " " + ball);
        }
    }
}
