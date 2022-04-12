using GUI_20212202_E4GBAX.Logic;
using GUI_20212202_E4GBAX.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_20212202_E4GBAX
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IGameWindowLogic logic;
        public ObservableCollection<SavedGame> SavedGames { get; set; }
        private SavedGame selectedSave;
        public SavedGame SelectedSave
        {
            get { return selectedSave; }
            set
            {
                SetProperty(ref selectedSave, value);
                (LoadGameCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand StartGameCommand { get; set; }
        public ICommand LoadGameCommand { get; set; }
        public ICommand QuitCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IGameWindowLogic>())
        {

        }


        public MainWindowViewModel(IGameWindowLogic logic)
        {
            this.logic = logic;
            SavedGames = new ObservableCollection<SavedGame>();
            SavedGames.Add(new SavedGame
            {
                Name = "Kristóf",
                Hp = 100,
                Level = 1
            });
            StartGameCommand = new RelayCommand(
                () => logic.StartGame()
                );
            LoadGameCommand = new RelayCommand(
                () => logic.LoadGame(SelectedSave),
                ()=>SelectedSave!=null
                );
        }
    }
}
