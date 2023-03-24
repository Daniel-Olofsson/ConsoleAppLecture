using CommunityToolkit.Mvvm.ComponentModel;
using System;


namespace WpfApp.Services;

internal class NavigationStore
{
    public event Action? CurrentViewModelChanged;

    private ObservableObject? currentViewModel;
    public ObservableObject? CurrentViewModel
    {
        get => currentViewModel;
        set
        {
            currentViewModel = value;
                OnCurrentViewModelChanged();
        }
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}
