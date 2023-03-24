using ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using WpfApp.Models.ViewModels;
using WpfApp.Services;

namespace WpfApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var statusService = new StatusService();
        Task.Run(statusService.InitializeAsync);

        var navigationStore = new NavigationStore();
        navigationStore.CurrentViewModel = new ActiveCaseViewModel(navigationStore);

        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(navigationStore)
        };

        MainWindow.Show();
            
        base.OnStartup(e);
    }
}
