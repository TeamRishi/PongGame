using System;
using System.Runtime.InteropServices;
using Pong.Models.Abstracts;
using Pong.UI;

namespace Pong.Core
{
    /// <summary>
    /// Input handler for the game.
    /// </summary>
    class InputHandler
    {
        /// <summary>
        /// Detects if movement keys are pressed.
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

        /// <summary>
        /// Game menu.
        /// </summary>
        /// <returns>Selected MenuOption</returns>
        public static MenuOption GameMode()
        {
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2, Utility.PlaygoundHeight / 2);
            int choice = int.Parse(Console.ReadLine());
            while (!(choice == 1 || choice == 2 || choice == 3))
            {
                choice = int.Parse(Console.ReadLine());
            }

            switch (choice)
            {
                case 1: return MenuOption.Singleplayer;
                case 2: return MenuOption.Mutiplayer;
                case 3: return MenuOption.Settings;
            }

            return MenuOption.Null;
        }
    }
}
