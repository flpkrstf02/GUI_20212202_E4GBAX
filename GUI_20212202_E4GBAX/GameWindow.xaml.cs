using GUI_20212202_E4GBAX.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI_20212202_E4GBAX
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        TowerDefenseLogic logic;
        public GameWindow()
        {
            InitializeComponent();
            logic = new TowerDefenseLogic();
            display.SetupModel(logic);
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DispatcherTimer dt = new DispatcherTimer();
            //dt.Interval = TimeSpan.FromMilliseconds(100);
            //dt.Tick += Dt_Tick;
            //dt.Start();
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(grid);
            logic.TowerPosition(new Size(grid.ActualWidth, grid.ActualHeight), p);
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();
        }
    }
}
