using System;
using Prism.Mvvm;
using GiTracker.Database;
using GiTracker.Services.Api;
using Prism.Navigation;
using Prism.Commands;
using GiTracker.Helpers;

namespace GiTracker.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        readonly IDatabaseService _databaseService;
        readonly INavigationService _navigationService;

		public MainPageViewModel(Loader loader, 
			IDatabaseService databaseService,
            INavigationService navigationService)
			: base(loader)
        {
            _databaseService = databaseService; // JUST AN EXAMPLE!
            _navigationService = navigationService;

            Title = "Main Page";
        }

        DelegateCommand _openIssueListCommand;
        public DelegateCommand OpenIssueListCommand
        {
            get { return _openIssueListCommand ?? (_openIssueListCommand = new DelegateCommand(OpenIssueList)); }
        }

        void OpenIssueList()
        {
            _navigationService.Navigate<IssueListViewModel>();
        }
    }
}
