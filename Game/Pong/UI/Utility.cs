using System;
using System.Media;
using System.Threading;
using Pong.Models.Game.Models;

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

        public const char BallChar = '\u25A0';
        public const char PaddleChar = '\u2588';

        public const int LeftPaddleX = 0;
        public const int LeftPaddleY = 12;
        public const int RightPaddleX = PlaygoundWidth - 1;
        public const int RightPaddleY = LeftPaddleY;
        public const int BallX = 42;
        public const int BallY = 18;
        public static ConsoleColor bgc = ConsoleColor.DarkGreen;
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            // TODO: Optimize speed by changing the value of the sleep command
            // and fix problem with lag before beep (beep found in Draw.cs at life method).
            Thread.Sleep(60);
        }

        public static Player GetWinner(Player one, Player two)
        {
            if (one.Lifes > two.Lifes)
            {
                return one;
            }

            return two;
        }

       
    }
}

                                       
