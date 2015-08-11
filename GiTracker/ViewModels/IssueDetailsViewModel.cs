using GiTracker.Helpers;
using GiTracker.Models;
using GiTracker.Services.Issues;
using GiTracker.Services.ServiceProvider;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class IssueDetailsViewModel : BaseViewModel
    {
        public const string IssueParameterName = "IssueParameterName";

        readonly IIssueService _issueService;

        public IssueDetailsViewModel(Loader loader,
			INavigationService navigationService,

            IGitServiceProvider gitServiceProvider)
			: base(loader, navigationService)
        {
            _issueService = gitServiceProvider.GetIssueService();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Issue = (IIssue)parameters[IssueParameterName];
        }

        IIssue _issue;
        public IIssue Issue
        {
            get { return _issue; }
            private set { SetProperty(ref _issue, value); }
        }        
    }
}
