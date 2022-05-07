using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_20212202_E4GBAX.Models
{
    public class Tower
    {
        private List<string> bullet;
        public int range { get; set; }
        public int damage { get; set; }
        public Point Center { get; set; }
        public int centerIdxX { get; set; }
        public int centerIdxY { get; set; }
        public int cost { get; set; }

       public int gold { get; set; }

        //elég-e a pénz a torony megvásárlásához
        public bool EnoughMoney(int gold, int cost)
        {
            bool enough = false;
            if (gold > cost)
            {
                enough = true;
            }
            else
            {
                enough = false;
            }

            return enough;  
        }

        

    }
}