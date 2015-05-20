using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Pong.UI
{
    class Sounds
    {
        public static void PlayingSounds(string soundeffect)
        {
            switch (soundeffect)
            {
                case "background":
                    using (SoundPlayer background = new SoundPlayer(@"Sounds\background.wav"))
                    {
                        background.PlayLooping();
                    }
                    break;
                case "gameover":
                    using (SoundPlayer gameover = new SoundPlayer(@"Sounds\gameover.wav"))
                    {
                        gameover.PlaySync();
                    }
                    break;

                //TODO
                /*case "menu":
                    using (SoundPlayer menu = new SoundPlayer(@"Sounds\....wav"))
                    {
                        menu.Play();
                    }
                    break;
                 */
            }
        }
    }
}
