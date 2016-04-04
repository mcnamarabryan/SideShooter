﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideShooter
{
    public class NewFrame
    {
        public NewFrame()
        {
            
        }

        public void CreateFrame(Graphics g)
        {
            SolidBrush tempBrush = new SolidBrush(Color.Black);

            g.FillRectangle(tempBrush, SideShooter.Main.TWindow.xOrigin, SideShooter.Main.TWindow.yOrigin, SideShooter.Main.TWindow.xMax, SideShooter.Main.TWindow.yMax);

            DrawStars(g);

            AnimateExplosions(g);
            AnimatePlayerShipExplosion(g);

            if (SideShooter.Main.ship.lives >= 0)
            {
                DrawLasers(g);
                DrawShip(g);

                DrawEnemies(g);
                DrawLives(g);
            }
        }

        public void DrawShip(Graphics g)
        {
            if (SideShooter.Main.ship.explosionFrame <= 0)
            {
                Point ulCorner = new Point(SideShooter.Main.ship.position.X, SideShooter.Main.ship.position.Y);
                Point urCorner = new Point(SideShooter.Main.ship.position.X + 40, SideShooter.Main.ship.position.Y);
                Point llCorner = new Point(SideShooter.Main.ship.position.X, SideShooter.Main.ship.position.Y + 40);
                Point[] destPara = { ulCorner, urCorner, llCorner };
                g.DrawImage(SideShooter.Main.assets.shipImage, destPara);
            }
        }

        public void DrawLasers(Graphics g)
        {
            int current = 0;
            Pen pen = new Pen(Color.IndianRed, 2.0f);

            while (current < SideShooter.Main.ship.shotsAlive)
            {
                g.DrawLine(pen, SideShooter.Main.ship.shotList[current], new Point(SideShooter.Main.ship.shotList[current].X - 10, SideShooter.Main.ship.shotList[current].Y));
                current++;
            }
        }

        public void DrawStars(Graphics g)
        {
            for (int i = 0; i < SideShooter.Main.DSBackground.starcount; i++)
            {
                g.DrawLine(new Pen(SideShooter.Main.DSBackground.colors[i], 2.0f), SideShooter.Main.DSBackground.stars[i], new Point(SideShooter.Main.DSBackground.stars[i].X - 3, SideShooter.Main.DSBackground.stars[i].Y));
            }

            for (int i = 0; i < SideShooter.Main.MSBackground.starcount; i++)
            {
                g.DrawLine(new Pen(SideShooter.Main.MSBackground.colors[i], 2.0f), SideShooter.Main.MSBackground.stars[i], new Point(SideShooter.Main.MSBackground.stars[i].X - 3, SideShooter.Main.MSBackground.stars[i].Y));
            }

            for (int i = 0; i < SideShooter.Main.FSBackground.starcount; i++)
            {
                g.DrawLine(new Pen(SideShooter.Main.FSBackground.colors[i], 1.0f), SideShooter.Main.FSBackground.stars[i], new Point(SideShooter.Main.FSBackground.stars[i].X - 1, SideShooter.Main.FSBackground.stars[i].Y));
            }
        }

        public void DrawLives(Graphics g)
        {
            int spacer = 15;

            for (int i=0; i < SideShooter.Main.ship.lives; i++)
            {
                Point ulCorner = new Point(SideShooter.Main.TWindow.xOrigin + spacer, SideShooter.Main.TWindow.yMax - 55);
                Point urCorner = new Point(ulCorner.X + 20, ulCorner.Y);
                Point llCorner = new Point(ulCorner.X, ulCorner.Y + 20);
                Point[] destPara = {ulCorner, urCorner, llCorner};
                g.DrawImage(SideShooter.Main.assets.shipImage, destPara);

                spacer += 25;
            }
        }

        public void DrawEnemies(Graphics g)
        {
            for (int i = 1; i <= SideShooter.Main.enemyWave.enemyCount; i++)
            {
                if (SideShooter.Main.enemyWave.enemyExplosionFrame[i] <= 0)
                {
                    Point ulCorner = new Point(SideShooter.Main.enemyWave.enemyPositions[i].X, SideShooter.Main.enemyWave.enemyPositions[i].Y);
                    Point urCorner = new Point(ulCorner.X + 30, ulCorner.Y);
                    Point llCorner = new Point(ulCorner.X, ulCorner.Y + 30);
                    Point[] destPara = { ulCorner, urCorner, llCorner };

                    g.DrawImage(SideShooter.Main.assets.enemyshipImage, destPara);
                }
            }
        }

        public void AnimateExplosions(Graphics g)
        {
            for (int i = 1; i <= SideShooter.Main.enemyWave.enemyCount; i++)
            {
                if (SideShooter.Main.enemyWave.enemyExplosionFrame[i] >= 2)
                {
                    Point ulCorner = new Point(SideShooter.Main.enemyWave.enemyPositions[i].X, SideShooter.Main.enemyWave.enemyPositions[i].Y);
                    Point urCorner = new Point(ulCorner.X + 30, ulCorner.Y);
                    Point llCorner = new Point(ulCorner.X, ulCorner.Y + 30);
                    Point[] destPara = { ulCorner, urCorner, llCorner };

                    g.DrawImage(SideShooter.Main.assets.explosion[SideShooter.Main.enemyWave.enemyExplosionFrame[i]], destPara);
                    SideShooter.Main.enemyWave.enemyExplosionFrame[i]--;
                }
                else if (SideShooter.Main.enemyWave.enemyExplosionFrame[i] == 1)
                {
                    SideShooter.Main.enemyWave.enemyExplosionFrame[i] = 0;
                    SideShooter.Main.enemyWave.EnemyDie(i);
                }
            }
        }

        public void AnimatePlayerShipExplosion(Graphics g)
        {
            if (SideShooter.Main.ship.explosionFrame >= 1)
            {
                Point ulCorner = new Point(SideShooter.Main.ship.position.X, SideShooter.Main.ship.position.Y);
                Point urCorner = new Point(SideShooter.Main.ship.position.X + 40, SideShooter.Main.ship.position.Y);
                Point llCorner = new Point(SideShooter.Main.ship.position.X, SideShooter.Main.ship.position.Y + 40);
                Point[] destPara = { ulCorner, urCorner, llCorner };
                g.DrawImage(SideShooter.Main.assets.explosion[SideShooter.Main.ship.explosionFrame], destPara);

                SideShooter.Main.ship.explosionFrame--;
            }
            if (SideShooter.Main.ship.explosionFrame == 1)
            {
                SideShooter.Main.ship.lives--;
                SideShooter.Main.ship.position.X = 100;
                SideShooter.Main.ship.position.Y = 220;
                if (SideShooter.Main.ship.lives < 0)
                {
                    SideShooter.Main.waitTimer = SideShooter.Main.frameCount + 30;
                }
            }
        }
    }
}
