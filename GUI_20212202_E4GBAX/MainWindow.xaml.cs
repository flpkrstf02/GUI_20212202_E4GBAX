using GUI_20212202_E4GBAX.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;
using System.Windows;

namespace GUI_20212202_E4GBAX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            img.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine("Images", "stonebg.jpg"), UriKind.RelativeOrAbsolute));
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e) => Close();
    }
}
