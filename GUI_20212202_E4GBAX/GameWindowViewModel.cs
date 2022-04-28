using GUI_20212202_E4GBAX.Logic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_20212202_E4GBAX
{
    public class GameWindowViewModel : ObservableRecipient
    {
        public ObservableCollection<int> TowerVariety { get; set; }
        private int selectedTower;
        public int SelectedTower
        {
            get { return selectedTower; }
            set { SetProperty(ref selectedTower, value); }
        }

        public int HP
        {
            get
            {
                return 0;
            }
        }

        public int Gold
        {
            get
            {
                return 0;
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        //public GameWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IGameModel>())
        //{

        //}
        public GameWindowViewModel()
        {
            TowerVariety = new ObservableCollection<int>();
            TowerVariety.Add(1);
            TowerVariety.Add(2);
            TowerVariety.Add(3);
            Messenger.Register<GameWindowViewModel, string, string>(this, "PlayerInfo", (recipient, msg) =>
            {
                OnPropertyChanged("PlayersHP");
                OnPropertyChanged("NumberOfGolds");
            });
        }
    }
}
