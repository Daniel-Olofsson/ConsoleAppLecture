using CommunityToolkit.Mvvm.ComponentModel;
using ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models.ViewModels;

internal class   NewCaseViewModel : ObservableObject
{
    private readonly NavigationStore? navigationStore;
    private readonly CaseService _caseService = new CaseService();

}
