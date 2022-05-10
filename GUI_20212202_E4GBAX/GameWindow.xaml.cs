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
        SavedGame savedGame;
        public GameWindow(SavedGame savedGame)
        {
            InitializeComponent();
            this.savedGame = savedGame;
            img.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine("Assets", "bg_ground_4.png"), UriKind.RelativeOrAbsolute));
            logic = new TowerDefenseLogic(savedGame,(new Size(grid.ActualWidth,grid.ActualHeight)));
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
                lb_hp.Content = logic.HP;
                lb_gold.Content = logic.Gold;
                display.InvalidateVisual();
                if (logic.GameOver())
                {
                    MessageBox.Show("Gamevover");
                    Close(); //TODO valami varázs ablak hogy Game Over
                    dt.Stop();
                }
                if (logic.GameCleared)
                {
                    MessageBox.Show("Congratulations you beat the game!");
                    Close();
                    dt.Stop();
                }
            };
            dt.Start();

            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();

            DispatcherTimer et = new DispatcherTimer();
            et.Interval = TimeSpan.FromMilliseconds(1000);
            et.Tick += (sender, eventargs) =>
            {
                logic.EnemySpawner(new Size(grid.ActualWidth, grid.ActualHeight));
            };
            et.Start();

            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();

            DispatcherTimer tT = new DispatcherTimer();
            tT.Interval = TimeSpan.FromMilliseconds(200);
            tT.Tick += (sender, eventargs) =>
            {
                logic.TowerAttack();
            };
            tT.Start();

            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();

            



        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(grid);
            logic.TowerPosition(new Size(grid.ActualWidth, grid.ActualHeight), p, int.Parse(cb_tower.SelectedItem.ToString()));
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
                    if (input.Name != savedGame.Name)
                    {
                        savedGames.Add(input);
                    }
                }
            }
            SavedGame save = logic.Save();
            if (save.Hp > 0 && save.Level<5)
            {
                savedGames.Add(save);
            }

            string jsonData = JsonConvert.SerializeObject(savedGames);
            File.WriteAllText("savedgames.json", jsonData);
        }

        private void Button_Click(object sender, RoutedEventArgs e) => Close();
    }
}
