using System;
using Prism.Mvvm;
using GiTracker.Database;

namespace GiTracker.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        readonly IDatabaseService _databaseService;

        public MainPageViewModel (IDatabaseService databaseService)
        {
            _databaseService = databaseService; // JUST AN EXAMPLE!

            Title = "Main Page";
        }
    }
}
