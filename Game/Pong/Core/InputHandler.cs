using System;

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
        /// <returns>"Up", "Down" or null if nothing is pressed.</returns>
        public static string PressedKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow)
                {
                    return "Up";
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    return "Down";
                }
            }

            return null;
        }
    }
}
