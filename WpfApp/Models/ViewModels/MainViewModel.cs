using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Services;

namespace WpfApp.Models.ViewModels;

internal partial class MainViewModel : ObservableObject
{
    private readonly NavigationStore? _navigationStore;

    public MainViewModel(NavigationStore? navigationStore)
    {
        _navigationStore = navigationStore;
        _navigationStore!.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    public ObservableObject CurrentViewModel => _navigationStore!.CurrentViewModel!;

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }


    [RelayCommand]
    public void NavigateToNewCase()
    {
        _navigationStore!.CurrentViewModel = new NewCaseViewModel(_navigationStore);
    }
}
