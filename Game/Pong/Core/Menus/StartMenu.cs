using Pong.Models.Abstracts;
using Pong.Models.Game.Models;
using Pong.UI;

namespace Pong.Core
{
    class StartMenu
    {
        public static void SinglePlayer()
        {
            Paddle leftPaddle = new Paddle(Utility.LeftPaddleX, Utility.LeftPaddleY, Utility.LeftPaddleX);
            Ball gameBall = new Ball(Utility.BallX, Utility.BallY);
            Player playerOne = new Player(Utility.lifes);

            while (playerOne.Lifes > 0)
            {
                Utility.SetField();

                Draw.Clear();
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

            Sounds.GameOver();
            Draw.GameOver();
            Utility.Delay();
        }

        public static void Mutiplayer()
        {
            Paddle leftPaddle = new Paddle(Utility.LeftPaddleX, Utility.LeftPaddleY, Utility.LeftPaddleX);
            Paddle rightPaddle = new Paddle(Utility.RightPaddleX, Utility.RightPaddleY, Utility.RightPaddleX);
            Player playerOne = new Player(Utility.lifes, "Left Player");
            Player playerTwo = new Player(Utility.lifes, "Right Player");
            Ball gameBall = new Ball(Utility.BallX, Utility.BallY);

            while (playerOne.Lifes > 0 && playerTwo.Lifes > 0)
            {
                Utility.SetField();

                Draw.Clear();
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

            Sounds.GameOver();
            Player winner = Utility.GetWinner(playerOne, playerTwo);
            Draw.GameOver(winner);
            Utility.Delay();
        }

        public static void GameSettings()
        {
            Draw.Clear();
            Draw.PrintGameSettings();
            SettingsOption option = InputHandler.GameSettings();

            switch (option)
            {
                case SettingsOption.GameSpeed:
                    SettingsMenu.SetSpeed();
                    break;
                case SettingsOption.Lifes:
                    SettingsMenu.SetLifes();
                    break;
                case SettingsOption.BackgroundColor:
                    SettingsMenu.SetBackgroundColor();
                    break;
                case SettingsOption.Return:
                    break;
            }
        }

        public static void ShowControls()
        {
            Draw.PrintControls();
            Utility.Delay();
        }
    }
}
