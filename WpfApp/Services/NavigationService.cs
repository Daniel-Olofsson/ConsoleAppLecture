using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Services;

internal class NavigationService
{
    public event Action? CurrentViewModelChanged;
    private ObservableObject? currentViewModel;
    public ObservableObject? currentViewModel
    {
        get => currentViewModel;
        set 
        {
            currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }
}
