using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_E4GBAX.Models
{
    public class SavedGame :ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        private int level;

        public int Level
        {
            get { return level; }
            set { SetProperty(ref level, value); }
        }
        private int hp;

        public int Hp
        {
            get { return hp; }
            set { SetProperty(ref hp, value); }
        }
        private int gold;

        public int Gold
        {
            get { return gold; }
            set { SetProperty(ref gold, value); }
        }
        private IList<Enemy> enemies;

        public IList<Enemy> Enemies
        {
            get { return enemies; }
            set { SetProperty(ref enemies, value); }
        }
        private IList<Tower> towers;

        public IList<Tower> Towers
        {
            get { return towers; }
            set { towers = value; }
        }
    }
}
