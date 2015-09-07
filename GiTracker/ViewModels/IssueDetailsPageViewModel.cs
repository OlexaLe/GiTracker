using System;
using System.Windows.Input;
using GiTracker.Models;
using GiTracker.Resources.Strings;
using GiTracker.Services.DataLoader;
using GiTracker.Services.Device;
using GiTracker.Services.Progress;
using Prism.Commands;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class IssueDetailsPageViewModel : BaseViewModel
    {
        public const string IssueParameterName = "IssueParameterName";
        public const string RepoParameterName = "RepoParameterName";
        private readonly IDeviceService _deviceService;
        private IssueViewModel _issue;
        private ICommand _logWorkCommand;
        private ICommand _openInBrowserCommand;
        private IRepo _repo;

        public IssueDetailsPageViewModel(IDeviceService deviceService,
            ILoader loader,
            IProgressService progressService,
            INavigationService navigationService)
            : base(loader, progressService, navigationService)
        {
            _deviceService = deviceService;
        }

        public IssueViewModel Issue
        {
            get { return _issue; }
            private set { SetProperty(ref _issue, value); }
        }

        public ICommand OpenInBrowserCommand =>
            _openInBrowserCommand ?? (_openInBrowserCommand = new DelegateCommand(OpenInBrowser));

        public ICommand LogWorkCommand =>
            _logWorkCommand ?? (_logWorkCommand = new DelegateCommand(LogWork));

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Issue = new IssueViewModel(parameters[IssueParameterName] as IIssue);
            _repo = parameters[RepoParameterName] as IRepo;

            Title = string.Format(IssueDetails.IssueNumber, Issue?.Number);
        }

        private void OpenInBrowser() => _deviceService.OpenUri(new Uri(Issue?.WebPage));

        private void LogWork()
        {
            NavigationService.Navigate<LogWorkPageViewModel>(
                new NavigationParameters
                {
                    {LogWorkPageViewModel.IssueParameterName, Issue.Issue},
                    {LogWorkPageViewModel.RepoParameterName, _repo}
                }, false);
        }
    }
}