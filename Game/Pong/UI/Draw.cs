using System;
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
            Console.SetCursorPosition(0, Utility.PlaygoundHeight - 1);
            Console.Write("Score: ");
        }

        public static void DrawLifes(int playerOneLifes)
        {
            Console.SetCursorPosition(25, Utility.PlaygoundHeight - 1);
            Console.Write("Player Left: {0}", playerOneLifes);
        }
        public static void DrawLifes(int playerOneLifes, int playerTwoLifes)
        {
            Console.SetCursorPosition(25, Utility.PlaygoundHeight - 1);
            Console.Write("Player Left: {0} : {1} Player Right", playerOneLifes, playerTwoLifes);
        }

        public static void GameOver()
        {
            Clear();
            string gameOver = "GAME OVER";
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - gameOver.Length / 2,
                Utility.PlaygoundHeight / 2);
            Console.WriteLine(gameOver);
        }
        public static void GameOver(Player winner)
        {
            Clear();
            string gameOver = "GAME OVER";
            string theWinner = string.Format("The winner is {0}", winner.Name);
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - gameOver.Length / 2,
                Utility.PlaygoundHeight / 2);
            Console.WriteLine(gameOver);
            Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - theWinner.Length / 2,
                Utility.PlaygoundHeight / 2 + 1);
            Console.WriteLine(theWinner);
        }


        public static void DrawDebug(Ball ball, Paddle paddle)
        {
            Console.SetCursorPosition(Utility.PaddleHeight, Utility.PlaygoundHeight - 2);
            Console.Write(ball.Direction + " " + paddle + " " + ball);
        }

        public static void StartupMenu()
        {

            Utility.SetField();
            Clear();
            string[] text =
            {
                "1.Single Player", "2.Two Players", "3.Game Settings","4.Exit", "Please type your choice:"
            };

            for (int i = 0; i < text.Length; i++)
            {
                Console.SetCursorPosition(Utility.PlaygoundWidth / 2 - text[i].Length / 2, Utility.PlaygoundHeight / 2 + i - text.Length);
                Console.WriteLine(text[i]);
            }
        }
    }
}
