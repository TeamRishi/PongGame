using System;
using System.Threading;

namespace Pong.UI
{
    /// <summary>
    /// Contains all utility information for the game.
    /// </summary>
    class Utility
    {
        /// <summary>
        /// Startup menu setup position:
        public const int SinglePlayerHeight = 14;
        public const int SinglePlayerWeight = 33;
        public const int TwoPlayersHeight = 15;
        public const int TwoPlayersWeight = 33;
        public const int GameSettingsHeight = 16;
        public const int GameSettingsWeight = 33;
        /// </summary>
        public const int PlaygoundHeight = 30;
        public const int PlaygoundWidth = 80;
        public const int PaddleHeight = 5;
        public const int BallSpeed = 1;
        public const int PaddleSpeed = 1;
        public const int Lifes = 3;
        public const char BallChar = '\u25A0';
        public const char PaddleChar = '\u2588';
        public const string cursor = "->";
        /// <summary>
        /// Changed Paddle X axis locations because of in which the ball would get between the wall and the paddle        resulting in a rapid lose of lifes.
        public const int LeftPaddleX = 0;
        /// </summary>
        public const int LeftPaddleY = 12;
        /// <summary>
        /// fixed same problem with right 
        public const int RightPaddleX = PlaygoundWidth-1 ;
        /// </summary>
        public const int RightPaddleY = 12;
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
            // Done.
            Console.BackgroundColor = ConsoleColor.White;
            ///<summary>
            /// Changed Object colors to black
            ///</summary>
            Console.ForegroundColor = ConsoleColor.Black;
            // TODO: Optimise speed by changing the value of the sleep command and fix problem with lag before beep (beep found in Draw.cs at life methode).
            Thread.Sleep(60);
        }
    }
}
