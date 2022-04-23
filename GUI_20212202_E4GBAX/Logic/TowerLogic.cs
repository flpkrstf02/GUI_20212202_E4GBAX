using GUI_20212202_E4GBAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using static GUI_20212202_E4GBAX.Logic.TowerDefenseLogic;

namespace GUI_20212202_E4GBAX.Logic
{
    public class TowerLogic: ITowerLogic
    {
        private List<string> bullet;

        public TowerLogic()
        { 
            
        }

        //alap torony, egy célpontot sebez egyszerre
        private void Tower1Maker(Tower t)
        {
            t.cost = 40;
            t.range = 2;
            t.damage = 2;
        }

        //az alap torony fejlesztése, nagyobb sebzéssel
        private void Tower12Maker(Tower t)
        {
            t.cost = 100;
            t.range = 6;
            t.damage = 8;
        }

        //különálló torony, területi sebzéssel
        private void Tower2Maker(Tower t)
        {
            t.cost = 125;
            t.range = 4;
            t.damage = 10;
        }




    }
}
