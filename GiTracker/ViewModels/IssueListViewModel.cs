using GiTracker.Helpers;
using GiTracker.Models;
using GiTracker.Resources.Strings;
using GiTracker.Services.Issues;
using GiTracker.Services.ServiceProvider;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
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

        ObservableCollection<IssueViewModel> _issues;
        public ObservableCollection<IssueViewModel> Issues
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
                Issues = new ObservableCollection<IssueViewModel>(issues.Select(issue => new IssueViewModel(issue)));
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

        DelegateCommand<IssueViewModel> _openIssueDetailsCommand;
        public DelegateCommand<IssueViewModel> OpenIssueDetailsCommand =>
            _openIssueDetailsCommand ?? (_openIssueDetailsCommand = new DelegateCommand<IssueViewModel>(OpenIssueDetails)); 

        void OpenIssueDetails(IssueViewModel issueViewModel)
        {
            NavigationService.Navigate<IssueDetailsViewModel>(new NavigationParameters { { IssueDetailsViewModel.IssueParameterName, issueViewModel } });
        }

        string _pageCenterText;
        public string PageCenterText
        {
            get { return _pageCenterText; }
            private set { SetProperty(ref _pageCenterText, value); }
        }
    }
}
