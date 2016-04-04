using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideShooter
{
    public class Sound
    {
        public Sound()
        {

        }

        public void PlayMusic()
        {

            SideShooter.Main.assets.soundMachine[1].Play();
        }

        public void PlayLaser()
        {            
            SideShooter.Main.assets.soundMachine[2].Play();
        }        

        public void PlayEnemyShipDie()
        {
            SideShooter.Main.assets.soundMachine[3].Play();
        }

        public void PlayUserShipDie()
        {
            SideShooter.Main.assets.soundMachine[5].Play();
        }

        public void PlayGameOver()
        {
            SideShooter.Main.assets.soundMachine[6].Play();
        }
    }
}
