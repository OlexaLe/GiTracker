using System;
using System.Windows.Input;
using GiTracker.Helpers;
using GiTracker.Resources.Strings;
using GiTracker.Services.Issues;
using GiTracker.Services.ServiceProvider;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

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
            
            Issue = parameters[IssueParameterName] as IssueViewModel;
            Title = string.Format(IssueDetails.IssueNumber, Issue?.Number);
        }

        IssueViewModel _issue;
        public IssueViewModel Issue
        {
            get { return _issue; }
            set { SetProperty(ref  _issue, value); }
        }
        
        ICommand _openInBrowserCommand;
        public ICommand OpenInBrowserCommand =>
            _openInBrowserCommand ?? (_openInBrowserCommand = new DelegateCommand(OpenInBrowser));

        void OpenInBrowser() => Device.OpenUri(new Uri(Issue?.WebPage));
    }
}
