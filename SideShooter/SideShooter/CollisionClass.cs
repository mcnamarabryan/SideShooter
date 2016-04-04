using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideShooter
{
    public class CollisionClass
    {
        public CollisionClass()
        {

        }

        public void CheckCollisions()
        {
            ShotsCollisionDetect();
            EntityCollisionDetect();
        }

        private void ShotsCollisionDetect()
        {
            for (int i = 0; i < SideShooter.Main.ship.shotsAlive; i++)
            {
                for (int i2 = 1; i2 <= SideShooter.Main.enemyWave.enemyCount; i2++)
                {
                    if (SideShooter.Main.enemyWave.enemyExplosionFrame[i2] <= 0)
                    {
                        if (((SideShooter.Main.ship.shotList[i].X >= SideShooter.Main.enemyWave.enemyPositions[i2].X) && (SideShooter.Main.ship.shotList[i].X <= (SideShooter.Main.enemyWave.enemyPositions[i2].X + 30)))
                            && ((SideShooter.Main.ship.shotList[i].Y >= SideShooter.Main.enemyWave.enemyPositions[i2].Y) && (SideShooter.Main.ship.shotList[i].Y <= (SideShooter.Main.enemyWave.enemyPositions[i2].Y + 30))))
                        {
                            SideShooter.Main.enemyWave.enemyExplosionFrame[i2] = 64;
                            SideShooter.Main.score += 50;
                            SideShooter.Main.SoundEngine.PlayEnemyShipDie();
                        }
                    }
                }
            }
        }

        private void EntityCollisionDetect()
        {
            for (int i = 1; i <= SideShooter.Main.enemyWave.enemyCount; i++ )
            {
                if (SideShooter.Main.enemyWave.enemyExplosionFrame[i] <= 0)
                {
                    if (((SideShooter.Main.enemyWave.enemyPositions[i].X <= (SideShooter.Main.ship.position.X + 25)) 
                            && (SideShooter.Main.enemyWave.enemyPositions[i].X >= SideShooter.Main.ship.position.X))
                        || (((SideShooter.Main.enemyWave.enemyPositions[i].X - 25) >= SideShooter.Main.ship.position.X)
                            && (SideShooter.Main.enemyWave.enemyPositions[i].X <= SideShooter.Main.ship.position.X)))
                    {
                        if (((SideShooter.Main.enemyWave.enemyPositions[i].Y >= SideShooter.Main.ship.position.Y) 
                                && (SideShooter.Main.enemyWave.enemyPositions[i].Y <= (SideShooter.Main.ship.position.Y + 25)))
                            || ((SideShooter.Main.enemyWave.enemyPositions[i].Y <= SideShooter.Main.ship.position.Y) 
                                && ((SideShooter.Main.enemyWave.enemyPositions[i].Y + 25) >= SideShooter.Main.ship.position.Y)))
                        {
                                SideShooter.Main.ship.ShipDie();
                        }                        
                    }
                }
            }
        }
    }
}
