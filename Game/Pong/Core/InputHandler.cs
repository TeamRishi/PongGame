using System;
using System.Linq;
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
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
            {
                Console.SetCursorPosition(Utility.PlaygoundWidth / 2, Utility.PlaygoundHeight / 2);
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1": return MenuOption.Singleplayer;
                case "2": return MenuOption.Mutiplayer;
                case "3": return MenuOption.Settings;
                case "4": return MenuOption.Controls;
                case "5": return MenuOption.Exit;
            }

            return MenuOption.Null;
        }

        public static SettingsOption GameSettings()
        {
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2, Utility.PlaygoundHeight / 2);
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2" && choice != "3" && choice != "4")
            {
                Console.SetCursorPosition(Utility.PlaygoundWidth / 2, Utility.PlaygoundHeight / 2);
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1": return SettingsOption.GameSpeed;
                case "2": return SettingsOption.Lifes;
                case "3": return SettingsOption.BackgroundColor;
                case "4": return SettingsOption.Return;
            }

            return SettingsOption.Return;
        }

        /// <summary>
        /// Input reader with validation for given range.
        /// </summary>
        /// <param name="start">Lower validation point</param>
        /// <param name="end">Upper validation point</param>
        /// <returns>Read int</returns>
        public static int MenuOptions(int start, int end)
        {
            if (start < 0 || end < 0 || end < start)
            {
                throw new ArgumentOutOfRangeException("Invalid numbers are given!");
            }

            int num = -1;
            while (num < start || num > end)
            {
                Console.SetCursorPosition(Utility.PlaygoundWidth / 2, Utility.PlaygoundHeight / 2);
                string choice = Console.ReadLine();

                try
                {
                    num = int.Parse(choice);
                }
                catch (FormatException) { }
            }

            return num;
        }

        /// <summary>
        /// Input reader for colors, with validation for { "red", "cyan", "yellow", "green", "magenta", "black" }
        /// </summary>
        /// <returns>BackgoundColor color</returns>
        public static BackgoundColor BackgroundColor()
        {
            string[] colors = { "red", "cyan", "yellow", "green", "magenta", "black" };

            Console.SetCursorPosition(Utility.PlaygoundWidth / 2, Utility.PlaygoundHeight / 2 + 1);
            string choice = Console.ReadLine();

            while (!colors.Contains(choice.ToLower()))
            {
                Console.SetCursorPosition(Utility.PlaygoundWidth / 2, Utility.PlaygoundHeight / 2 + 1);
                choice = Console.ReadLine();
            }

            BackgoundColor selectedColor = BackgoundColor.Black;
            switch (choice.ToLower())
            {
                case "red":
                    selectedColor = BackgoundColor.Red;
                    break;
                case "cyan":
                    selectedColor = BackgoundColor.Cyan;
                    break;
                case "yellow":
                    selectedColor = BackgoundColor.Yellow;
                    break;
                case "green":
                    selectedColor = BackgoundColor.Green;
                    break;
                case "magenta":
                    selectedColor = BackgoundColor.Magenta;
                    break;
                case "black":
                    selectedColor = BackgoundColor.Black;
                    break;
            }

            return selectedColor;
        }
    }
}
