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

		public MainPageViewModel(Loader loader, 
			IDatabaseService databaseService,
            INavigationService navigationService)
			: base(loader, navigationService)
        {
            _databaseService = databaseService; // JUST AN EXAMPLE!

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
