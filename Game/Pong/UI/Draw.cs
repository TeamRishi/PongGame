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
                Console.Write('|');
            }
        }

        // TODO: Fix it!
        public static void DrawScore()
        {
            Console.SetCursorPosition(0, Utility.PlaygoundHeight - Utility.PaddleHeight);
            Console.Write("Score: ");
        }
    }
}
