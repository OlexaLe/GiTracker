using System;
using System.Collections.Generic;
using System.Windows.Input;
using GiTracker.Helpers;
using GiTracker.Models;
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
        IIssue _issue;

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

            _issue = (IIssue)parameters[IssueParameterName];

            Title = string.Format(IssueDetails.IssueNumber, _issue.Number);

            OnPropertyChanged(() => Number);
            OnPropertyChanged(() => Name);
            OnPropertyChanged(() => Body);
            OnPropertyChanged(() => Url);
            OnPropertyChanged(() => Status);
            OnPropertyChanged(() => Labels);
            OnPropertyChanged(() => Author);
            OnPropertyChanged(() => Assignee);
            OnPropertyChanged(() => CreatedAt);
            OnPropertyChanged(() => UpdatedAt);
            OnPropertyChanged(() => ClosedAt);
        }

        public int? Number => _issue?.Number;
        public string Name => _issue?.Title;
        public string Body => _issue?.Body;
        public string Url => _issue?.Url;
        public IssueStatus? Status => _issue?.Status;
        public IEnumerable<ILabel> Labels => _issue?.Labels;
        public IUser Author => _issue?.Author;
        public IUser Assignee => _issue?.Assignee;
        public DateTime? CreatedAt => _issue?.CreatedAt?.ToLocalTime();
        public DateTime? UpdatedAt => _issue?.UpdatedAt?.ToLocalTime();
        public DateTime? ClosedAt => _issue?.ClosedAt?.ToLocalTime();

        ICommand _openInBrowserCommand;
        public ICommand OpenInBrowserCommand =>
            _openInBrowserCommand ?? (_openInBrowserCommand = new DelegateCommand(OpenInBrowser));

        void OpenInBrowser() => Device.OpenUri(new Uri(_issue?.WebPage));
    }
}
