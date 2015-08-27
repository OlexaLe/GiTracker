using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GiTracker.Helpers;
using GiTracker.Models;
using GiTracker.Resources.Strings;
using GiTracker.Services.Issues;
using Prism.Commands;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    internal class IssueListTabViewModel : BaseViewModel
    {
        private readonly IIssueService _issueService;
        private ObservableCollection<IssueViewModel> _issues;
        private DelegateCommand<IssueViewModel> _openIssueDetailsCommand;
        private string _pageCenterText;
        private DelegateCommand _updateIssuesCommand;

        public IssueListTabViewModel(Loader loader,
            IIssueService issueService,
            INavigationService navigationService)
            : base(loader, navigationService)
        {
            _issueService = issueService;
        }

        public virtual IssueStatus? IssueStatus { get; }

        public ObservableCollection<IssueViewModel> Issues
        {
            get { return _issues; }
            private set { SetProperty(ref _issues, value); }
        }

        public DelegateCommand UpdateIssuesCommand =>
            _updateIssuesCommand ?? (_updateIssuesCommand = new DelegateCommand(UpdateIssues));

        public DelegateCommand<IssueViewModel> OpenIssueDetailsCommand =>
            _openIssueDetailsCommand ??
            (_openIssueDetailsCommand = new DelegateCommand<IssueViewModel>(OpenIssueDetails));

        public string PageCenterText
        {
            get { return _pageCenterText; }
            private set { SetProperty(ref _pageCenterText, value); }
        }

        private async Task LoadIssuesAsync()
        {
            PageCenterText = Shared.Loading;

            Issues?.Clear();
            await Loader.LoadAsync(async cancellationToken =>
            {
                var issues =
                    await _issueService.GetIssuesAsync(cancellationToken, "XamarinGarage/GiTracker", IssueStatus);
                Issues = new ObservableCollection<IssueViewModel>(issues.Select(issue => new IssueViewModel(issue)));
            });

            PageCenterText = string.Empty;
        }

        private async void UpdateIssues()
        {
            await LoadIssuesAsync();
        }

        private void OpenIssueDetails(IssueViewModel issueViewModel)
        {
            NavigationService.Navigate<IssueDetailsViewModel>(
                new NavigationParameters {{IssueDetailsViewModel.IssueParameterName, issueViewModel}}, false);
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
    }

    internal class OpenIssueTabViewModel : IssueListTabViewModel
    {
        public OpenIssueTabViewModel(Loader loader,
            IIssueService issueService,
            INavigationService navigationService)
            : base(loader, issueService, navigationService)
        {
            Title = IssueList.OpenTabTitle;
        }

        public override IssueStatus? IssueStatus => Models.IssueStatus.Open;
    }

    internal class ClosedIssueTabViewModel : IssueListTabViewModel
    {
        public ClosedIssueTabViewModel(Loader loader,
            IIssueService issueService,
            INavigationService navigationService)
            : base(loader, issueService, navigationService)
        {
            Title = IssueList.ClosedTabTitle;
        }

        public override IssueStatus? IssueStatus => Models.IssueStatus.Closed;
    }
}