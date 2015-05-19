using System;
using Pong.Models.Game.Models;
using Pong.UI;

namespace Pong.Core
{
    class Game
    {
        public static void Main()
        {
            Paddle leftPaddle = new Paddle(1, 0);
            Ball gameBall = new Ball(10, 10);

            while (true)
            {
                Utility.SetField();

                Draw.Clear();
                //Draw.DrawScore();
                Draw.DrawPaddle(leftPaddle);

                string pressedKey = InputHandler.PressedKey();
                switch (pressedKey)
                {
                    case "Up":
                        leftPaddle.UpdateY(-1);
                        break;
                    case "Down":
                        leftPaddle.UpdateY(1);
                        break;
                }
            }
        }
    }
}
