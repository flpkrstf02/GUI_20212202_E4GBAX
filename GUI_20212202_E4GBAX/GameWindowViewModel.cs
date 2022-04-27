using GUI_20212202_E4GBAX.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_E4GBAX
{
    public class GameWindowViewModel:ObservableRecipient
    {
        public ObservableCollection<int> TowerVariety { get; set; }
        private int selectedTower;

        public int SelectedTower
        {
            get { return selectedTower; }
            set { SetProperty(ref selectedTower, value); }
        }
        public GameWindowViewModel()
        {
            TowerVariety = new ObservableCollection<int>();
            TowerVariety.Add(1);
            TowerVariety.Add(2);
            TowerVariety.Add(3);
        }

    }
}
