using System;
using Prism.Mvvm;
using GiTracker.Database;

namespace GiTracker.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        readonly IDatabaseService _databaseService;

        public MainPageViewModel (IDatabaseService databaseService)
        {
            _databaseService = databaseService; // JUST AN EXAMPLE!
        }

        string _title = "Main Page";

        public string Title {
            get { return _title; }
            set { SetProperty (ref _title, value); }
        }
    }
}
