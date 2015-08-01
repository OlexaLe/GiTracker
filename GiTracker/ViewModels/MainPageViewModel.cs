using System;
using Prism.Mvvm;
using GiTracker.Database;
using GiTracker.Services.Api;

namespace GiTracker.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        readonly IDatabaseService _databaseService;
        readonly IGitApiService _gitApiService;

        public MainPageViewModel (IDatabaseService databaseService,
            IGitApiServiceFactory gitApiServiceFactory)
        {
            _databaseService = databaseService; // JUST AN EXAMPLE!
            _gitApiService = gitApiServiceFactory.GetApiService();  // JUST AN EXAMPLE!

            Title = "Main Page";
        }
    }
}
