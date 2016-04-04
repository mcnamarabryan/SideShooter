using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SideShooter
{
    public class TranslatedWindow
    {
        public int xOrigin, yOrigin, xMax, yMax = 0;
        public Point center = new Point(0, 0);

        public TranslatedWindow(Form mainForm)
        {
            xOrigin = mainForm.Location.X;
            yOrigin = mainForm.Location.Y;
            xMax = mainForm.Width;
            yMax = mainForm.Height;
            center.X = (xMax - xOrigin) + xOrigin;
            center.Y = (yMax - yOrigin) + yOrigin;
        }
    }
}
