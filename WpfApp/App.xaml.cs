using ConsoleApp.Models.Entities;
using ConsoleApp.Services;
using Microsoft.Win32;
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
    protected override async void OnStartup(StartupEventArgs e)
    {
        var statusService = new StatusService();
        var caseService = new CaseService();
        await Task.Run(statusService.InitializeAsync);
        var cEntity = new CustomerEntity
        {

        };
        var entity = new CaseEntity();
        
        var result = await caseService.CreateAsync(entity);


        //var customerService = new CustomerService();
        //var currentUser = await customerService.GetAllAsync();
        
        Console.WriteLine(result);
            

        //if (currentUser == null)
        //{

        //}


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
