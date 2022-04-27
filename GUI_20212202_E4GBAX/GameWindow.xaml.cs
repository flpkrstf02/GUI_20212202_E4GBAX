using GUI_20212202_E4GBAX.Logic;
using GUI_20212202_E4GBAX.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GUI_20212202_E4GBAX
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        TowerDefenseLogic logic;
        public GameWindow(SavedGame savedGame)
        {
            InitializeComponent();
            logic = new TowerDefenseLogic(savedGame);
            display.SetupModel(logic);
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(100);
            dt.Tick += (sender, eventargs) =>
            {
                logic.TimeStep(new Size(grid.ActualWidth, grid.ActualHeight));
                display.InvalidateVisual();
            };
            dt.Start();
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(grid);
            logic.TowerPosition(new Size(grid.ActualWidth, grid.ActualHeight), p,int.Parse(cb_tower.SelectedItem.ToString()));
            logic.EnemySpawner(new Size(grid.ActualWidth, grid.ActualHeight));
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            List<SavedGame> savedGames = new List<SavedGame>();
            if (File.Exists("savedgames.json"))
            {
                var inputs = JsonConvert.DeserializeObject<SavedGame[]>(File.ReadAllText("savedgames.json"));
                foreach (var input in inputs)
                {
                    savedGames.Add(input);
                }
            }
            SavedGame save = logic.Save();
            savedGames.Add(save);
            string jsonData=JsonConvert.SerializeObject(savedGames);
            File.WriteAllText("savedgames.json", jsonData);
            
        }
    }
}
