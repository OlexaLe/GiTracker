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

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            await LoadIssuesAsync();
        }

        ObservableCollection<IIssue> _issues = new ObservableCollection<IIssue>();
        public ObservableCollection<IIssue> Issues
        {
            get { return _issues; }
            private set { SetProperty(ref _issues, value); }
        }

        async Task LoadIssuesAsync()
        {
            try
            {
                await Loader.LoadAsync(async (cancellationToken) =>
                {
                    var issues = await _gitApiService.GetIssuesAsync(cancellationToken);
                    Issues = new ObservableCollection<IIssue>(issues);
                });
            }
            catch (Exception e)
            { }
        }

        DelegateCommand _updateIssuesCommand;
        public DelegateCommand UpdateIssuesCommand
        {
            get { return _updateIssuesCommand ?? (_updateIssuesCommand = new DelegateCommand(UpdateIssues)); }
        }

        async void UpdateIssues()
        {
            await LoadIssuesAsync();
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
