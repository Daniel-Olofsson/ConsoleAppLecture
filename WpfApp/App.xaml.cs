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
    private readonly CustomerService customerService =new();
    protected override async void OnStartup(StartupEventArgs e)
    {
        var statusService = new StatusService();
        var caseService = new CaseService();
        var getStatus = await statusService.GetAsync(x=> x.Id == 2);

        var getCustomer = await customerService.GetAsync(x=> x.Id == 1);

        var _case = new CaseEntity()
        {

            Description = "new banana case",
            Created = DateTime.Now,
            Modified = DateTime.Now,
            //Customer = getCustomer,
            //Status = getStatus,

        };
        var customerObj = new CustomerEntity()
        {
            CustomerName = "new user kiwi",
            Email = "newkiwi@domain.com",
            Cases = new List<CaseEntity> { _case }

        };

        var createCustomer = await customerService.CreateAsync(customerObj);


        var customer = await customerService.GetAllAsync();

        foreach (var customerItem in customer)
        {
            Console.WriteLine($"{customerItem.CustomerName}");
        }



        //var create = await caseService.CreateAsync(_case);


        //var current = await caseService.GetAllAsync();

        //foreach (var item in current)
        //{
        //    Console.WriteLine($"{item.Id} - {item.Modified} - {item.Description}");
        //    //Console.WriteLine($"{item.Status}");
        //}


        await Task.Run(statusService.InitializeAsync);


        //
        //var currentUser = await customerService.GetAllAsync();




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
