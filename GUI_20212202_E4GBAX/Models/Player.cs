using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GUI_20212202_E4GBAX.Models
{
    public class Player
    {
        private int gold;
        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }
        private int hp;
        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }
        public Player()
        {
            gold = 100;
            hp = 100;
        }

    }
}
