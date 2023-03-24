using CommunityToolkit.Mvvm.ComponentModel;
using ConsoleApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using WpfApp.Services;

namespace WpfApp.Models.ViewModels;

internal partial class CaseViewModel : ObservableObject
{
    private readonly NavigationStore _navigationStore;

    public CaseViewModel(int id, NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
    }
}
