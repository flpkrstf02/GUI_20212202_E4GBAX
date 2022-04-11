using GUI_20212202_E4GBAX.Logic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
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
        public ICommand StartGameCommand { get; set; }
        public MainWindowViewModel(IGameWindowLogic logic)
        {
            this.logic = logic;
            StartGameCommand = new RelayCommand(
                () => logic.StartGame()
                );

        }
    }
}
