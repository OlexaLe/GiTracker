using GiTracker.Helpers;
using GiTracker.Models;
using GiTracker.Services.Api;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class IssueDetailsViewModel : BaseViewModel
    {
        public const string IssueParameterName = "IssueParameterName";

        readonly IGitApiService _gitApiService;

		public IssueDetailsViewModel(Loader loader, 
			IGitApiServiceFactory gitApiServiceFactory)
			: base(loader)
        {
            _gitApiService = gitApiServiceFactory.GetApiService();
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
