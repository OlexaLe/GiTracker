using GiTracker.Models;
using GiTracker.Services.Api;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class IssueDetailsViewModel : BaseViewModel
    {
        public const string IssueParameterName = "IssueParameterName";

        readonly IGitApiService _gitApiService;

        public IssueDetailsViewModel(IGitApiServiceFactory gitApiServiceFactory)
        {
            _gitApiService = gitApiServiceFactory.GetApiService();
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            var a = (IIssue)parameters[IssueParameterName];
        }
    }
}
