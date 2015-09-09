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
        private readonly IDeviceService _deviceService;
        private IssueViewModel _issue;
        private ICommand _logWorkCommand;
        private ICommand _openInBrowserCommand;
        private ICommand _openWorkLogsCommand;
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
            set { SetProperty(ref _issue, value); }
        }

        public ICommand OpenInBrowserCommand =>
            _openInBrowserCommand ?? (_openInBrowserCommand = new DelegateCommand(OpenInBrowser));

        public ICommand LogWorkCommand =>
            _logWorkCommand ?? (_logWorkCommand = new DelegateCommand(LogWork));

        public ICommand OpenWorkLogsCommand
            => _openWorkLogsCommand ?? (_openWorkLogsCommand = new DelegateCommand(OpenWorkLogs));

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Issue = new IssueViewModel(parameters[Constants.IssueParameterName] as IIssue);
            _repo = parameters[Constants.RepoParameterName] as IRepo;

            Title = string.Format(IssueDetails.IssueNumber, Issue?.Number);
        }

        private void OpenInBrowser() => _deviceService.OpenUri(new Uri(Issue?.WebPage));

        private void LogWork()
        {
            NavigationService.Navigate<LogWorkPageViewModel>(
                new NavigationParameters
                {
                    {Constants.IssueParameterName, Issue.Issue},
                    {Constants.RepoParameterName, _repo}
                }, false);
        }

        private void OpenWorkLogs()
        {
            NavigationService.Navigate<WorkLogsPageViewModel>(
                new NavigationParameters
                {
                    {Constants.IssueParameterName, Issue.Issue},
                    {Constants.RepoParameterName, _repo}
                }, false);
        }
    }
}