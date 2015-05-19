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

        public static void DrawDebug(Ball ball, Paddle paddle)
        {
            Console.SetCursorPosition(10, Utility.PlaygoundHeight - 1);
            Console.Write(ball.Direction + " " + paddle + " " + ball);
        }
    }
}
