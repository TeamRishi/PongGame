using System;
using Pong.Models.Abstracts;
using Pong.UI;

namespace Pong.Core
{
    /// <summary>
    /// All settings in the setting menu.
    /// </summary>
    class SettingsMenu
    {
        public static void SetSpeed()
        {
            Draw.PrintSpeedSettings();
            int speed = InputHandler.MenuOptions(1, 5);
            switch (speed)
            {
                case 1:
                    Utility.gameSpeed = 100;
                    break;
                case 2:
                    Utility.gameSpeed = 80;
                    break;
                case 3:
                    Utility.gameSpeed = 60;
                    break;
                case 4:
                    Utility.gameSpeed = 40;
                    break;
                case 5:
                    Utility.gameSpeed = 20;
                    break;
            }
        }

        public static void SetLifes()
        {
            Draw.PrintLifeSettings();
            int lifes = InputHandler.MenuOptions(1, 100);
            Utility.lifes = lifes;
        }

        public static void SetBackgroundColor()
        {
            Draw.Clear();
            Draw.PrintBackgroundColorSettings();
            BackgoundColor selectedColor = InputHandler.BackgroundColor();
            switch (selectedColor)
            {
                case BackgoundColor.Red:
                    Utility.beckgroundColor = ConsoleColor.DarkRed;
                    break;
                case BackgoundColor.Cyan:
                    Utility.beckgroundColor = ConsoleColor.DarkCyan;
                    break;
                case BackgoundColor.Yellow:
                    Utility.beckgroundColor = ConsoleColor.DarkYellow;
                    break;
                case BackgoundColor.Green:
                    Utility.beckgroundColor = ConsoleColor.DarkGreen;
                    break;
                case BackgoundColor.Magenta:
                    Utility.beckgroundColor = ConsoleColor.DarkMagenta;
                    break;
                case BackgoundColor.Black:
                    Utility.beckgroundColor = ConsoleColor.Black;
                    break;
            }
        }
    }
}
