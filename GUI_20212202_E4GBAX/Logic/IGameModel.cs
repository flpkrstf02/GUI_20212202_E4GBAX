using GUI_20212202_E4GBAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GUI_20212202_E4GBAX.Logic.TowerDefenseLogic;

namespace GUI_20212202_E4GBAX.Logic
{
    public interface IGameModel
    {
        TowerItem[,] GameMatrix { get; set; }
        event EventHandler Changed;
        List<Enemy> Enemies { get; set; }
        List<Tower> Towers { get; set; }
    }
}
