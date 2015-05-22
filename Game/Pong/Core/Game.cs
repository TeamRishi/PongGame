using System;
using System.ComponentModel.Design;
using System.Net.Mime;
using System.Threading;
using Pong.Models.Abstracts;
using Pong.Models.Game.Models;
using Pong.UI;

namespace Pong.Core
{
    internal class Game
    {
        /// <summary>
        /// Singleplayer mode.
        /// </summary>
        private static void SinglePlayer()
        {
            Paddle leftPaddle = new Paddle(Utility.LeftPaddleX, Utility.LeftPaddleY, Utility.LeftPaddleX);
            Ball gameBall = new Ball(Utility.BallX, Utility.BallY);
            Player playerOne = new Player(Utility.Lifes);

            while (playerOne.Lifes > 0)
            {
                Utility.SetField();
                
                Console.BackgroundColor = Utility.bgc;
                Console.Clear();
                Draw.DrawPaddle(leftPaddle);
                Draw.DrawBall(gameBall);
                Draw.DrawLifes(playerOne.Lifes);

                Direction pressedKey = InputHandler.PressedKey();
                switch (pressedKey)
                {
                    case Direction.LeftPaddleUp:
                        leftPaddle.Update(Utility.PaddleSpeed, Direction.Up);
                        break;
                    case Direction.LeftPaddleDown:
                        leftPaddle.Update(Utility.PaddleSpeed, Direction.Down);
                        break;
                }
                

                gameBall.Update(Utility.BallSpeed, gameBall.Direction);

                ColisionDetector.CheckPaddleColision(leftPaddle, gameBall);
                playerOne.Lifes = ColisionDetector.CheckLifeLoss(playerOne.Lifes, gameBall, leftPaddle);


            }

            Draw.GameOver();
            
        }

        /// <summary>
        /// Multiplayer mode.
        /// </summary>
        private static void Mutiplayer()
        {
            Paddle leftPaddle = new Paddle(Utility.LeftPaddleX, Utility.LeftPaddleY, Utility.LeftPaddleX);
            Paddle rightPaddle = new Paddle(Utility.RightPaddleX, Utility.RightPaddleY, Utility.RightPaddleX);
            Player playerOne = new Player(Utility.Lifes, "Left Player");
            Player playerTwo = new Player(Utility.Lifes, "Right Player");
            Ball gameBall = new Ball(Utility.BallX, Utility.BallY);

            while (playerOne.Lifes > 0 && playerTwo.Lifes > 0)
            {
                Utility.SetField();

                Console.BackgroundColor = Utility.bgc;
                Console.Clear();
                Draw.DrawPaddle(leftPaddle);
                Draw.DrawPaddle(rightPaddle);

                Draw.DrawBall(gameBall);
                Draw.DrawLifes(playerOne.Lifes, playerTwo.Lifes);

                Direction pressedKey = InputHandler.PressedKey();
                switch (pressedKey)
                {
                    case Direction.LeftPaddleUp: 
                        leftPaddle.Update(Utility.PaddleSpeed, Direction.Up);
                        break;
                    case Direction.LeftPaddleDown:
                        leftPaddle.Update(Utility.PaddleSpeed, Direction.Down);
                        break;
                    case Direction.RightPaddleUp:
                        rightPaddle.Update(Utility.PaddleSpeed, Direction.Up);
                        break;
                    case Direction.RightPaddleDown:
                        rightPaddle.Update(Utility.PaddleSpeed, Direction.Down);
                        break;
                }

                gameBall.Update(Utility.BallSpeed, gameBall.Direction);

                ColisionDetector.CheckPaddleColision(leftPaddle, gameBall);
                ColisionDetector.CheckPaddleColision(rightPaddle, gameBall);
                playerOne.Lifes = ColisionDetector.CheckLifeLoss(playerOne.Lifes, gameBall, leftPaddle);
                playerTwo.Lifes = ColisionDetector.CheckLifeLoss(playerTwo.Lifes, gameBall, rightPaddle);
            }

            Player winner = Utility.GetWinner(playerOne, playerTwo);
            Draw.GameOver(winner);
        }

        public static void GameSettings()
        {
            Utility.SetField();

            Console.BackgroundColor = Utility.bgc;
            Console.Clear();
            while (true)
            {
                Draw.StartUpSettings();
            }
        }

        public static int Speed()
        {
            int speed = 100;
            switch (Draw.GameSpeed())
            {
                case 1:
                    speed = 100;
                    break;
                case 2:
                    speed = 80;
                    break;
                case 3:
                    speed = 60;
                    break;
                case 4:
                    speed = 40;
                    break;
                case 5:
                    speed = 20;
                    break;
            }
            return speed;
        }

        public static void Main()
        {
            while (true)
            {

                Sounds.Background();
                Draw.StartupMenu();
                MenuOption option = InputHandler.GameMode();
                if (option == MenuOption.Singleplayer)
                {
                    SinglePlayer();
                }

                if (option == MenuOption.Mutiplayer)
                {
                    Mutiplayer();
                }
                if (option == MenuOption.Settings)
                {
                    GameSettings();
                }
                if (option == MenuOption.Exit)
                {
                    Environment.Exit(0);
                }

                Sounds.GameOver();

            }
            
        }
    }
}
