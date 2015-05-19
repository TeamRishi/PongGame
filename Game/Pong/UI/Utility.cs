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
        public const int PaddleHeight = 5;
        public const char BallChar = '*';
        public const char PaddleChar = '|'; 
        
        /// <summary>
        /// Sets all console settings.
        /// </summary>
        public static void SetField()
        {
            Console.WindowHeight = PlaygoundHeight;
            Console.BufferHeight = Console.WindowHeight;
            Console.CursorVisible = false;
            // TODO: add colors to the console.
            //Console.BackgroundColor = ConsoleColor.White;

            Thread.Sleep(100);
        }
    }
}
