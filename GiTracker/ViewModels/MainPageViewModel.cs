using GiTracker.Helpers;
using Prism.Commands;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private DelegateCommand _openIssueListCommand;

        public MainPageViewModel(Loader loader,
            INavigationService navigationService)
            : base(loader, navigationService)
        {
            Title = "Main Page";
        }

        public DelegateCommand OpenIssueListCommand =>
            _openIssueListCommand ?? (_openIssueListCommand = new DelegateCommand(OpenIssueList));

        private void OpenIssueList()
        {
            NavigationService.Navigate<IssueListViewModel>(null, false);
        }
    }
}