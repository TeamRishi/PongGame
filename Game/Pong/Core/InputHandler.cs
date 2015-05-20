using System;
using Pong.Models.Abstracts;

namespace Pong.Core
{
    /// <summary>
    /// Input handler for the game.
    /// </summary>
    class InputHandler
    {
        /// <summary>
        /// Detects if "arrow up" or "arrow down" are pressed.
        /// </summary>
        /// <returns>Direction</returns>
        public static Direction PressedKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Q)
                {
                    return Direction.LeftPaddleUp;
                }

                if (key.Key == ConsoleKey.A)
                {
                    return Direction.LeftPaddleDown;
                }
                if (key.Key == ConsoleKey.P)
                {
                    return Direction.RightPaddleUp;
                }

                if (key.Key == ConsoleKey.L)
                {
                    return Direction.RightPaddleDown;
                }
            }

            return Direction.Null;
        }
    }
}
