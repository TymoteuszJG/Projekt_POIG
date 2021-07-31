using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt_Poig
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static void ChangeCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            var oldWindow = Current.MainWindow;
            var x = oldWindow.Top;
            var y = oldWindow.Left;

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Top = x;
            Current.MainWindow.Left = y;
            Current.MainWindow.Show();
            oldWindow.Close();
        }

    }
}
