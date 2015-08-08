using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GiTracker.Helpers;
using GiTracker.Models;
using GiTracker.Services.Api;
using Prism.Commands;
using Prism.Navigation;
using GiTracker.Resources.Strings;

namespace GiTracker.ViewModels
{
    public class IssueListViewModel : BaseViewModel
    {
        readonly IGitApiService _gitApiService;

        public IssueListViewModel(Loader loader, 
			IGitApiServiceFactory gitApiServiceFactory,
            INavigationService navigationService)
			: base(loader, navigationService)
        {
            _gitApiService = gitApiServiceFactory.GetApiService();
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            await LoadIssuesAsync();
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            Loader.CancelLoading();

            base.OnNavigatedFrom(parameters);
        }

        ObservableCollection<IIssue> _issues;
        public ObservableCollection<IIssue> Issues
        {
            get { return _issues; }
            private set { SetProperty(ref _issues, value); }
        }

        async Task LoadIssuesAsync()
        {
            PageCenterText = Shared.Loading;

            Issues?.Clear();
            await Loader.LoadAsync(async (cancellationToken) =>
            {
                var issues = await _gitApiService.GetIssuesAsync(cancellationToken);
                Issues = new ObservableCollection<IIssue>(issues);
            });

            PageCenterText = string.Empty;
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

        string _pageCenterText;
        public string PageCenterText
        {
            get { return _pageCenterText; }
            private set { SetProperty(ref _pageCenterText, value); }
        }
    }
}
