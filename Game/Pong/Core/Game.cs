using Pong.Models.Abstracts;
using Pong.UI;

namespace Pong.Core
{
    internal class Game
    {
        public static void Main()
        {
            MenuOption option = MenuOption.Null;

            while (option != MenuOption.Exit)
            {
                Draw.Clear();
                Sounds.Background();
                Draw.PrintStartupMenu();
                option = InputHandler.GameMode();
                switch (option)
                {
                    case MenuOption.Singleplayer:
                        StartMenu.SinglePlayer();
                        break;
                    case MenuOption.Mutiplayer:
                        StartMenu.Mutiplayer();
                        break;
                    case MenuOption.Settings:
                        StartMenu.GameSettings();
                        break;
                    case MenuOption.Controls:
                        StartMenu.ShowControls();
                        break;
                }
            }
        }
    }
}
