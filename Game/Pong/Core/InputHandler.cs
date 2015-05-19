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
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow)
                {
                    return Direction.Up;
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    return Direction.Down;
                }
            }

            return Direction.Null;
        }
    }
}
