using GiTracker.Helpers;
using GiTracker.Models;
using GiTracker.Resources.Strings;
using GiTracker.Services.Issues;
using GiTracker.Services.ServiceProvider;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace GiTracker.ViewModels
{
    public class IssueListViewModel : BaseViewModel
    {
        readonly IIssueService _issueService;

        public IssueListViewModel(Loader loader,
            IGitServiceProvider gitServiceProvider,
            INavigationService navigationService)
			: base(loader, navigationService)
        {
            _issueService = gitServiceProvider.GetIssueService();
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
            await Loader.LoadAsync(async cancellationToken =>
            {
                var issues = await _issueService.GetIssuesAsync(cancellationToken);
                Issues = new ObservableCollection<IIssue>(issues);
            });

            PageCenterText = string.Empty;
        }

        DelegateCommand _updateIssuesCommand;
        public DelegateCommand UpdateIssuesCommand => 
            _updateIssuesCommand ?? (_updateIssuesCommand = new DelegateCommand(UpdateIssues)); 
        

        async void UpdateIssues()
        {
            await LoadIssuesAsync();
        }

        DelegateCommand<IIssue> _openIssueDetailsCommand;
        public DelegateCommand<IIssue> OpenIssueDetailsCommand =>
            _openIssueDetailsCommand ?? (_openIssueDetailsCommand = new DelegateCommand<IIssue>(OpenIssueDetails)); 

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
