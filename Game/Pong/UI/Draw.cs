using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Pong.Core;
using Pong.Models.Game.Models;

namespace Pong.UI
{
    /// <summary>
    /// Holds all the drawing.
    /// </summary>
    class Draw
    {
        public static void Clear()
        {
            Console.Clear();
        }

        public static void DrawPaddle(Paddle paddle)
        {
            for (int i = 0; i < Utility.PaddleHeight; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(paddle.X, paddle.Y + i);
                Console.Write(Utility.PaddleChar);
            }
        }

        public static void DrawBall(Ball ball)
        {
            try
            {
                Console.SetCursorPosition(ball.X, ball.Y);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(Utility.BallChar);
                Console.ResetColor();
            }
            catch (ArgumentOutOfRangeException)
            {
                // Failsafe in case ball goes in the corner of the field.
                ball.X = Utility.BallX;
                ball.Y = Utility.BallY;
            }
        }

        // TODO: Implement score and fix here!
        public static void DrawScore()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, Utility.PlaygoundHeight - 1);
            Console.Write("Score: ");
        }

        public static void DrawLifes(int playerOneLifes)
        {
            Console.SetCursorPosition(25, Utility.PlaygoundHeight - 1);
            Console.BackgroundColor = Utility.bgc;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Player Left: {0}", playerOneLifes);
        }
        public static void DrawLifes(int playerOneLifes, int playerTwoLifes)
        {
            Console.SetCursorPosition(25, Utility.PlaygoundHeight - 1);
            Console.BackgroundColor = Utility.bgc;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Player Left: {0} : {1} Player Right", playerOneLifes, playerTwoLifes);
        }

        public static void GameOver()
        {
            Clear();
            Console.BackgroundColor = Utility.bgc;
            Console.ForegroundColor = ConsoleColor.White;
            PrintGameOver();
        }
        public static void GameOver(Player winner)
        {
            Clear();
            Console.BackgroundColor = Utility.bgc;
            Console.ForegroundColor = ConsoleColor.White;
            PrintGameOver();
            string theWinner = string.Format("The winner is {0}", winner.Name);
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - theWinner.Length / 2,
                Utility.PlaygoundHeight / 2 + 1);
            Console.WriteLine(theWinner);
        }


        public static void DrawDebug(Ball ball, Paddle paddle)
        {
            Console.SetCursorPosition(Utility.PaddleHeight, Utility.PlaygoundHeight - 2);
            Console.Write(ball.Direction + " " + paddle + " " + ball);
        }

        public static void MenuBackground()
        {
            Utility.SetField();
            Clear();
            Console.BackgroundColor = Utility.bgc;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            GameName();
            Credits();
        }
        public static void StartupMenu()
        {

            MenuBackground();
            string[] text =
            {
                "1.Single Player", "2.Two Players", "3.Game Settings", "4.Exit", "Please type your choice:"
            };

            for (int i = 0; i < text.Length; i++)
            {
                Console.SetCursorPosition(Utility.PlaygoundWidth/2 - text[i].Length/2,
                    Utility.PlaygoundHeight/2 + i - text.Length);
                Console.WriteLine(text[i]);
            }
        }
        public static void StartUpSettings()
        {
            Clear();
            MenuBackground();
        string[] GameStartUpSettings =
            {
                "1.GameSpeed", "2.Lifes", "3.Background color change","4.Return to start menu"
            };
            for (int i = 0; i < GameStartUpSettings.Length; i++)
            {
                Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - GameStartUpSettings[i].Length / 2,
                    Utility.PlaygoundHeight / 2 + i - GameStartUpSettings.Length);
                Console.WriteLine(GameStartUpSettings[i]);
            }
            Console.SetCursorPosition(40,Utility.PlaygoundHeight/2);
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: GameSpeed();
                    break;
                case 2: GameLifes();
                    break;
                case 3: BackgroundChange();
                    break;
                case 4: Game.Main();
                    break;
            }
        }

        public static int GameSpeed()
        {
            Clear();
            MenuBackground();
            string SetSpeed = "Set game speed (0 - 5):";
            Console.SetCursorPosition(28,Utility.PlaygoundHeight/2-3);
            Console.WriteLine(SetSpeed);
            Console.SetCursorPosition(28+SetSpeed.Length/2,Utility.PlaygoundHeight/2-2);
            int choice =int.Parse(Console.ReadLine());
            return choice;
        }
        public static int GameLifes()
        {
            Clear();
            MenuBackground();
            string SetLifes = "Set game lifes (0 - 100):";
            Console.SetCursorPosition(28, Utility.PlaygoundHeight / 2-3);
            Console.WriteLine(SetLifes);
            Console.SetCursorPosition(28 + SetLifes.Length / 2, Utility.PlaygoundHeight / 2 -2);
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public static string BackgroundChange()
        {
            Clear();
            MenuBackground();
            string BackgroundColor = "Set game background color (White,Black,Red,Green,Blue,Yellow):";
            Console.SetCursorPosition(10,Utility.PlaygoundHeight/2-3);
            Console.WriteLine(BackgroundColor);
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2-3, Utility.PlaygoundHeight / 2-2);
            string choice =Console.ReadLine();
            return choice;
        }

        public static void GameName()
        {

            using (StreamReader source = new StreamReader(@"Textures/GameName.txt"))
            {
                string line = source.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = source.ReadLine();
                }
            }
                
        }
        public static void Credits()
        {
            using (StreamReader source = new StreamReader(@"Textures/Credits.txt"))
            {
                string line = source.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = source.ReadLine();
                }
            }
        }

        public static void PrintGameOver()
        {
            using (StreamReader source = new StreamReader(@"Textures/GameOver.txt"))
            {
                string line = source.ReadLine();
                while (line != null)
                {
                    Console.SetCursorPosition(Utility.PlaygoundWidth-20,Utility.PlaygoundHeight-10);
                    Console.WriteLine(line);
                    line = source.ReadLine();
                }
            }
        }
        /// <summary>
        /// TODO: make a working instance of a outer border
        /// </summary>
        //public static void Borders()
        //{
        //    Utility.SetField();
        //    int[,] matrixField = new int[30,80];
        //    int i = 0;
        //    int j = 0;
        //    while (0<i && i<= 80)
        //    {
        //        Console.WriteLine("{0}",new string('-',matrixField[0,i]));
        //        Console.WriteLine("{0}",new string('-',matrixField[30,i]));
        //        i++;
        //    }
        //}
    }
}
