using System;
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

        public const char BallChar = '\u25A0';
        public const char PaddleChar = '\u2588';

        public const int LeftPaddleX = 0;
        public const int LeftPaddleY = 12;
        public const int RightPaddleX = PlaygoundWidth - 1;
        public const int RightPaddleY = LeftPaddleY;
        public const int BallX = 42;
        public const int BallY = 18;

        public static ConsoleColor beckgroundColor = RandomBackgroundColor();
        public static int lifes = 3;
        public static int gameSpeed = 100;

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
            SetConsoleColors();

            Thread.Sleep(gameSpeed);
        }

        public static void SetConsoleColors()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = Utility.beckgroundColor;
        }

        public static Player GetWinner(Player one, Player two)
        {
            if (one.Lifes > two.Lifes)
            {
                return one;
            }
            
            return two;
        }

        public static void Delay()
        {
            int n = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (n == int.MaxValue)
                {
                    break;
                }

                n++;
            }
        }

        private static ConsoleColor RandomBackgroundColor()
        {
            Random rng = new Random();
            int num = rng.Next(0, 6);
            ConsoleColor backgroundColor = ConsoleColor.Black;

            switch (num)
            {
                case 0:
                    backgroundColor = ConsoleColor.DarkRed;
                    break;
                case 1:
                    backgroundColor = ConsoleColor.DarkCyan;
                    break;
                case 2:
                    backgroundColor = ConsoleColor.DarkYellow;
                    break;
                case 3:
                    backgroundColor = ConsoleColor.DarkGreen;
                    break;
                case 4:
                    backgroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 5:
                    backgroundColor = ConsoleColor.Black;
                    break;
            }

            return backgroundColor;
        }
    }
}