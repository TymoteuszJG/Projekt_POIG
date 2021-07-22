using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            InitializeComponent();
            loadStateOfApp();



        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem CB_Item = (ComboBoxItem)CB_Lang.SelectedItem;

            string version = CB_Item.Tag.ToString();
            
            App.ChangeCulture(version);
        }

        public void loadStateOfApp()
        {
            var ustawienia = Properties.Settings.Default;
            //cbChangeLan.SelectedIndex = ustawienia.cbChangeLanSelectedIndex;

            //ComboBoxItem cb = (ComboBoxItem)cbChangeLan.Items[1];
            var kultura = Thread.CurrentThread.CurrentCulture.Name;
            switch (kultura)
            {
                case "pl-PL": CB_Lang.SelectedIndex = 0; break;
                case "en-US": CB_Lang.SelectedIndex = 1; break;
                default: CB_Lang.SelectedIndex = -1; break;
            }
            
        }


    }
}
