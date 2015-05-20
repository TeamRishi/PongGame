using System;
using System.Threading;

namespace Pong.UI
{
    /// <summary>
    /// Contains all utility information for the game.
    /// </summary>
    class Utility
    {
        public const int PlaygoundHeight = 30;
        public const int PlaygoundWidth = 80;
        public const int PaddleHeight = 5;
        public const int BallSpeed = 1;
        public const int PaddleSpeed = 1;
        public const int Lifes = 3;
        public const char BallChar = '*';
        public const char PaddleChar = '|';
        public const int LeftPaddleX = 3;
        public const int LeftPaddleY = 12;
        public const int BallX = 42;
        public const int BallY = 18;
        
        /// <summary>
        /// Sets all console settings.
        /// </summary>
        public static void SetField()
        {
            Console.WindowHeight = PlaygoundHeight;
            Console.WindowWidth = PlaygoundWidth;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
            // TODO: add colors to the console.
            //Console.BackgroundColor = ConsoleColor.White;

            Thread.Sleep(100);
        }
    }
}
