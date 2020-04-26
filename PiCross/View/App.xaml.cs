using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new MainWindow();
            MainViewModel viewModel = new MainViewModel();
            MainWindow.DataContext = viewModel;
            mainWindow.Show();
            viewModel.Close += AppExit;
        }

        private void AppExit()
        {
            Application.Current.Shutdown();
        }
    }
}
