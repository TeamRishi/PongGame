using System;
using System.IO;
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
                Console.SetCursorPosition(paddle.X, paddle.Y + i);
                Console.Write(Utility.PaddleChar);
            }
        }

        public static void DrawBall(Ball ball)
        {
            try
            {
                Console.SetCursorPosition(ball.X, ball.Y);
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

        // TODO: Implement score
        public static void DrawScore()
        {
            Utility.SetConsoleColors();
            Console.SetCursorPosition(0, Utility.PlaygoundHeight - 1);
            Console.Write("Score: ");
        }

        public static void DrawLifes(int playerOneLifes)
        {
            Utility.SetConsoleColors();
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2, Utility.PlaygoundHeight - 1);
            Console.Write("Player Left: {0}", playerOneLifes);
        }

        public static void DrawLifes(int playerOneLifes, int playerTwoLifes)
        {
            Utility.SetConsoleColors();
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2, Utility.PlaygoundHeight - 1);
            Console.Write("Player Left: {0} : {1} Player Right", playerOneLifes, playerTwoLifes);
        }

        public static void GameOver()
        {
            Clear();
            PrintGameOver();
        }

        public static void GameOver(Player winner)
        {
            Clear();
            PrintGameOver();
            string theWinner = string.Format("The winner is {0}", winner.Name);
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - theWinner.Length / 2,
                Utility.PlaygoundHeight / 2 + Utility.PlaygoundHeight / 10);
            Console.WriteLine(theWinner);
        }

        public static void DrawDebug(Ball ball, Paddle paddle)
        {
            Console.SetCursorPosition(Utility.PaddleHeight, Utility.PlaygoundHeight - 2);
            Console.Write(ball.Direction + " " + paddle + " " + ball);
        }

        public static void PrintMenuBackground()
        {
            Utility.SetField();
            Clear();
            PrintGameName();
            Credits();
        }

        public static void PrintStartupMenu()
        {
            PrintMenuBackground();
            string[] text =
            {
                "1.Single Player", "2.Two Players", "3.Game Settings", "4.Controls", "5.Exit", "Please type your choice:"
            };

            for (int i = 0; i < text.Length; i++)
            {
                Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - text[i].Length / 2,
                    Utility.PlaygoundHeight / 2 + i - text.Length);
                Console.WriteLine(text[i]);
            }
        }

        public static void PrintGameSettings()
        {
            Clear();
            PrintMenuBackground();
            string[] gameStartUpSettings =
            {
                "1.Game Speed", "2.Lifes", "3.Background color change", "4.Return to start menu"
            };
            for (int i = 0; i < gameStartUpSettings.Length; i++)
            {
                Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - gameStartUpSettings[i].Length / 2,
                    Utility.PlaygoundHeight / 2 + i - gameStartUpSettings.Length);
                Console.WriteLine(gameStartUpSettings[i]);
            }
        }

        public static void PrintSpeedSettings()
        {
            Clear();
            PrintMenuBackground();
            string setSpeed = "Set game speed (1 to 5):";
            Console.SetCursorPosition(Utility.PlaygoundHeight / 2 - setSpeed.Length / 3, Utility.PlaygoundHeight / 2);
            Console.WriteLine(setSpeed);
            Console.SetCursorPosition(Utility.PlaygoundHeight / 2 - setSpeed.Length / 3, Utility.PlaygoundHeight / 2 + 1);
            Console.WriteLine("slow to fast");
        }

        public static void PrintLifeSettings()
        {
            Clear();
            PrintMenuBackground();
            string setLifes = "Set game lifes (0 - 100):";
            Console.SetCursorPosition(Utility.PlaygoundHeight / 2 - setLifes.Length / 3, Utility.PlaygoundHeight / 2);
            Console.WriteLine(setLifes);
        }

        public static void PrintBackgroundColorSettings()
        {
            Clear();
            PrintMenuBackground();
            string backgroundColor = "Set game background color:";
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - backgroundColor.Length / 2, Utility.PlaygoundHeight / 2 - 1);
            Console.WriteLine(backgroundColor);
            string choices = "Red, Cyan, Yellow, Green, Magenta, Black";
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - choices.Length / 2, Utility.PlaygoundHeight / 2);
            Console.WriteLine(choices);
        }

        public static void PrintControls()
        {
            Clear();
            PrintMenuBackground();
            string leftPlayer = "Left player moves with 'q' and 'a'";
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - leftPlayer.Length / 2, Utility.PlaygoundHeight / 2 - 1);
            Console.WriteLine(leftPlayer);
            string rightPlayer = "Right player moves with 'p' and 'l'";
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - rightPlayer.Length / 2, Utility.PlaygoundHeight / 2);
            Console.WriteLine(rightPlayer);
            string ret = "You will be returned to the menu shortly!";
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - ret.Length / 2, Utility.PlaygoundHeight / 2 + 1);
            Console.WriteLine(ret);
        }

        public static void PrintGameName()
        {
            using (StreamReader source = new StreamReader(@"..\..\Resources\Textures/GameName.txt"))
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
            using (StreamReader source = new StreamReader(@"..\..\Resources\Textures\Credits.txt"))
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
            Utility.SetConsoleColors();
            using (StreamReader source = new StreamReader(@"..\..\Resources\Textures\GameOver.txt"))
            {
                string line = source.ReadLine();
                int row = Utility.PlaygoundHeight / 3;
                while (line != null)
                {
                    Console.SetCursorPosition(0, 0 + row);
                    Console.WriteLine(line);
                    line = source.ReadLine();
                    row++;
                }
            }
        }

        // TODO: Outer border
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
