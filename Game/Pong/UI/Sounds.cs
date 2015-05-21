using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pong.UI
{
    /// <summary>
    /// Contains all the music for the game.
    /// </summary>
    class Sounds
    {
        /// <summary>
        /// Background music.
        /// </summary>
        public static void Background()
        {
            using (SoundPlayer background = new SoundPlayer(@"Sounds\background.wav"))
            {
                background.PlayLooping();
            }
        }

        /// <summary>
        /// Game Over music.
        /// </summary>
        public static void GameOver()
        {
            using (SoundPlayer gameOver = new SoundPlayer(@"Sounds\gameover.wav"))
            {
                gameOver.PlaySync();
            }
        }

        public static void Beep()
        {
            Thread beep = new Thread(Console.Beep);
            beep.Start();
        }

        // TODO: menu music.
        /*  using (SoundPlayer menu = new SoundPlayer(@"Sounds\....wav"))
            {
                menu.Play();
            }
            break;
         */
    }
}
