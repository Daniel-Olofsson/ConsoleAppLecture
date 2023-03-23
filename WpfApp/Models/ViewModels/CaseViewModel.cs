using CommunityToolkit.Mvvm.ComponentModel;
using ConsoleApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace WpfApp.Models.ViewModels;

internal partial class CaseViewModel : ObservableObject
{
    private readonly CaseService _caseService = new CaseService();
    private readonly NavigationService _navigationService;

    
    [ObservableProperty]
    private ObservableCollection<CaseEntity> cases = new ObservableCollection<CaseEntity>()

    public CaseViewModel(NavigationService navigationService)
    {
        GetCases();
        _navigationService = navigationService;
    }

    public ObservableCollection<CaseEntity> Cases
    {
        get { return cases; }
        set { SetProperty(ref cases, value); }
    }
    private void GetCases()
    {
        var result = Task.Run(_caseService.GetAllAsync).Result;
        result = result.OrderByDescending(x => x.Created);

        foreach (var _case in result)
            Cases.Add(_case);
    }
}
