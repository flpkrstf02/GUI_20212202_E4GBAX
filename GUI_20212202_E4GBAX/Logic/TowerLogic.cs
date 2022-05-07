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
    public class TowerLogic : ITowerLogic
    {


        public TowerLogic()
        {

        }

        //alap torony, egy célpontot sebez egyszerre
        public Tower Tower1Maker(Point p, int x, int y)
        {
            Tower t = new Tower();
            t.cost = 40;
            t.range = 2;
            t.damage = 2;
            t.Center = p;
            t.centerIdxX = x;
            t.centerIdxY = y;
            return t;
        }

        //az alap torony fejlesztése, nagyobb sebzéssel
        public Tower Tower12Maker(Point p, int x, int y)
        {
            Tower t = new Tower();
            t.cost = 100;
            t.range = 6;
            t.damage = 8;
            t.Center = p;
            t.centerIdxX = x;
            t.centerIdxY = y;
            return t;
        }

        //különálló torony, Teljes pályás hatótávval
        public Tower Tower2Maker(Point p, int x, int y)
        {
            Tower t = new Tower();
            t.cost = 125;
            t.range = 10000;
            t.damage = 10;
            t.Center = p;
            t.centerIdxX = x;
            t.centerIdxY = y;
            return t;
        }









    }
}
