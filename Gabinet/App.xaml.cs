using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjektZaliczeniowy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Gabinet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var context = new GabinetContext();
            var mainWindow = new MainWindow(context);

            mainWindow.Show();
        }
    }
}