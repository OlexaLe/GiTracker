using System.Collections.Generic;
using GiTracker.Helpers;
using GiTracker.Resources.Strings;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    internal class IssueListViewModel : BaseViewModel
    {
        public IssueListViewModel(Loader loader,
            INavigationService navigationService,
            OpenIssueTabViewModel openIssuesTabViewModel,
            ClosedIssueTabViewModel closedIssuesTabViewModel)
            : base(loader, navigationService)
        {
            Title = IssueList.Title;

            Tabs = new IssueListTabViewModel[] {openIssuesTabViewModel, closedIssuesTabViewModel};
        }

        public IEnumerable<IssueListTabViewModel> Tabs { get; }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            foreach (var tab in Tabs)
                tab.OnNavigatedTo(parameters);
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            foreach (var tab in Tabs)
                tab.OnNavigatedFrom(parameters);

            base.OnNavigatedFrom(parameters);
        }
    }
}