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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projekt_Poig.ViewModel;
using Projekt_Poig.Commands;

namespace Projekt_Poig
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Navigation navigation = new Navigation();
            DataContext = new NavigateViewModel(navigation);
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent(); 
        }
    }
}
