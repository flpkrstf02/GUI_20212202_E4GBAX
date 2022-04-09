using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_E4GBAX.Logic
{
    public class TowerDefenseLogic
    {
        public char[,] GameMatrix { get; set; }
        public TowerDefenseLogic(string path)
        {
            StreamReader sr=new StreamReader(path);
            
        }
    }
}
