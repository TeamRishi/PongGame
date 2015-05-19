using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Core
{
    class Game
    {
       public static void Main()
        {
            while (true)
            {
                //TODO: Add UI.SetField -> set console settings.
                string pressedKey = InputHandler.PressedKey();
                switch (pressedKey)
                {
                    case "Up":
                        //TODO: Add logic.
                        Console.WriteLine("pressed up");
                        break;
                    case "Down":
                        //TODO: Add logic.
                        Console.WriteLine("pressed down");
                        break;
                }
            }
        }
    }
}
