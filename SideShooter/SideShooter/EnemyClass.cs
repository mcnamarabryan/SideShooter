using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideShooter
{
    public class EnemyClass
    {
        public Point[] enemyPositions = new Point[200];
        public int[] enemyExplosionFrame = new int[200];
        public int enemyCount = 0;
        public int enemyTendancy = 0;
        public bool modX, modY = false;
        public int distX, distY = 0;

        public EnemyClass(int waveDifficulty)
        {
            

                
            
        }

        public void InitializeEnemies(int waveDifficulty)
        {
            enemyCount = 0;

            for (int i = 0; i <= 199;i++ )
            {
                enemyPositions[i].X = 0;
                enemyPositions[i].Y = 0;
            }

            for (int i = 0; i < 199; i++)
            {
                enemyExplosionFrame[i] = 0;
            }

            int ySpawn = 80;

            for (int i = 1; i <= waveDifficulty; i++)
            {
                enemyCount++;
                if (i < 8)
                {
                    enemyPositions[i] = new Point(SideShooter.Main.TWindow.xMax - 50, ySpawn);
                    if (i == 7)
                        ySpawn = 80;
                    else
                        ySpawn += 45;
                }
                else if (i < 16)
                {
                    enemyPositions[i] = new Point(SideShooter.Main.TWindow.xMax - 100, ySpawn);
                    if (i == 15)
                        ySpawn = 80;
                    else
                        ySpawn += 45;
                }
                else if (i < 24)
                {
                    enemyPositions[i] = new Point(SideShooter.Main.TWindow.xMax - 100, ySpawn);
                    if (i == 23)
                        ySpawn = 80;
                    else
                        ySpawn += 45;
                }
                else if (i < 32)
                {
                    enemyPositions[i] = new Point(SideShooter.Main.TWindow.xMax - 100, ySpawn);
                    if (i == 31)
                        ySpawn = 80;
                    else
                        ySpawn += 45;
                }
                
            }

            if (waveDifficulty <= 5)
            {
                enemyTendancy = 0;
            }
            else if (waveDifficulty <= 8)
            {
                enemyTendancy = 1;
            }
            else if (waveDifficulty <= 11)
            {
                enemyTendancy = 2;
            }
            else if (waveDifficulty <= 15)
            {
                enemyTendancy = 3;
            }
        }

        public void EnemyMove()
        {            
            //find out where they're headed
            CalculateEnemyMove();
            //...then physically move enemies
            for (int i = 1; i <= enemyCount; i++)
            {
                if (enemyExplosionFrame[i] <= 0)
                {
                    if (modX)
                    {
                        enemyPositions[i].X += distX;
                    }
                    if (modY)
                    {
                        enemyPositions[i].Y += distY;
                    }
                }
            }
        }

        private void CalculateEnemyMove()
        {
            DetermineIfPastScreen();

            modX = false;
            modY = false;

            switch (enemyTendancy)
            {
                case 0:
                    {
                        modX = true;
                        distX = -6;
                        distY = 0;
                        break;
                    }
                case 1:
                    {
                        modX = true;
                        modY = true;
                        distX = -8;

                        double angle = Convert.ToDouble(enemyPositions[1].X) * 5;
                        distY = Convert.ToInt32(Math.Sin(angle));
                        break;
                    }
                case 2:
                    {
                        modX = true;
                        modY = false;
                        distX = -10;
                        distY = 0;
                        break;
                    }
                case 3:
                    {
                        modX = true;
                        modY = true;
                        distX = -12;

                        double angle = Convert.ToDouble(enemyPositions[1].X) * 5;
                        distY = -(Convert.ToInt32(Math.Sin(angle)));

                        break;
                    }
            }
        }

        private void DetermineIfPastScreen()
        {
            for (int i=1; i<= enemyCount; i++)
            {
                if (enemyPositions[i].X <= -10)
                {
                    EnemyDie(i);
                }
            }
        }

        public void EnemyDie(int currentEnemy)
        {
            for (int i = currentEnemy; i <= enemyCount; i++)
            {
                enemyPositions[i] = enemyPositions[i+1];
                enemyExplosionFrame[i] = enemyExplosionFrame[i + 1];
            }
            enemyCount--;
        }
    }
}
