using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_20212202_E4GBAX.Logic
{
    public class Enemy
    {
        public Enemy(Point center, Vector speed)
        {
            Center = center;
            Speed = speed;
        }

        public Point Center { get; set; }

        public Vector Speed { get; set; }
        public int Health { get; set; }

        public bool Move(Size area)
        {
            //hova kerülne a lépéskor a lövedék
            Point newCenter =new Point(Center.X + (int)Speed.X,Center.Y + (int)Speed.Y);
            if (newCenter.X >= 0 &&
                newCenter.X <= area.Width &&
                newCenter.Y >= 0 &&
                newCenter.Y <= area.Height
                )
            {
                //pályán belül van a lövedék
                Center = newCenter;
                return true;
            }
            else
            {
                //épp elhagyta a pályát
                return false;
            }
        }
    }
}
