using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GiTracker.Models;
using GiTracker.Services.Api;
using Prism.Commands;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class IssueListViewModel : BaseViewModel
    {
        readonly IGitApiService _gitApiService;
        readonly INavigationService _navigationService;

        public IssueListViewModel(IGitApiServiceFactory gitApiServiceFactory,
            INavigationService navigationService)
        {
            _gitApiService = gitApiServiceFactory.GetApiService();
            _navigationService = navigationService;
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            UpdateIssues();
        }

        ObservableCollection<IIssue> _issues;
        public ObservableCollection<IIssue> Issues
        {
            get { return _issues; }
            private set { SetProperty(ref _issues, value); }
        }

        Task LoadIssuesAsync()
        {
            return _loader.LoadAsync(async (cancellationToken) =>
            {
                var issues = await _gitApiService.GetIssuesAsync(cancellationToken);
                Issues = new ObservableCollection<IIssue>(issues);
            });
        }

        DelegateCommand _updateIssuesCommand;
        public DelegateCommand UpdateIssuesCommand
        {
            get { return _updateIssuesCommand ?? (_updateIssuesCommand = new DelegateCommand(UpdateIssues)); }
        }

        async void UpdateIssues()
        {
            try
            {
                await LoadIssuesAsync();
            }
            catch (Exception e)
            { }
        }

        DelegateCommand<IIssue> _openIssueDetailsCommand;
        public DelegateCommand<IIssue> OpenIssueDetailsCommand
        {
            get { return _openIssueDetailsCommand ?? (_openIssueDetailsCommand = new DelegateCommand<IIssue>(OpenIssueDetails)); }
        }

        void OpenIssueDetails(IIssue issue)
        {
            _navigationService.Navigate<IssueDetailsViewModel>(new NavigationParameters { { IssueDetailsViewModel.IssueParameterName, issue } });
        }
    }
}
