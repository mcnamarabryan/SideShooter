using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideShooter
{
    public class ForeSpaceBackground
    {
        public int starcount = 75;
        public Point[] stars = new Point[75];
        public Color[] colors = new Color[75];
        public int colorIndex = 1;

        public ForeSpaceBackground()
        {
            int newRandX, newRandY = 0;
            for (int i = 0; i < starcount; i++)
            {
                newRandX = SideShooter.Main.randNum.Next(SideShooter.Main.TWindow.xOrigin, SideShooter.Main.TWindow.xMax);
                newRandY = SideShooter.Main.randNum.Next(SideShooter.Main.TWindow.yOrigin, SideShooter.Main.TWindow.yMax);
                stars[i] = new Point(newRandX, newRandY);

                if (colorIndex == 1)
                        {
                            colors[i] = Color.FromArgb(100, 100, 100, 100);
                            colorIndex = 2;
                        }
                else if (colorIndex == 2)
                        {
                            colors[i] = Color.FromArgb(100, 255,100,100);
                            colorIndex = 3;
                        }
                else if (colorIndex == 3)
                        {
                            colors[i] = Color.FromArgb(100, 100, 100, 255);
                            colorIndex = 1;
                        }
                
            }
        }

        public void ForeMoveStars()
        {
            for (int i=0; i < starcount; i++)
            {
                stars[i].X -= 3;
                if (stars[i].X < 0)
                {
                    stars[i].X = SideShooter.Main.TWindow.xMax;
                    stars[i].Y = SideShooter.Main.randNum.Next(SideShooter.Main.TWindow.yOrigin, SideShooter.Main.TWindow.yMax);
                    
                }
            }
        }
    }
}
