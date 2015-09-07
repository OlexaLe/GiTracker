using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Input;
using GiTracker.Models;
using GiTracker.Resources.Strings;
using GiTracker.Services.DataLoader;
using GiTracker.Services.Progress;
using GiTracker.Services.WorkLog;
using Prism.Commands;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class LogWorkPageViewModel : BaseViewModel
    {
        public const string IssueParameterName = "IssueParameterName";
        public const string RepoParameterName = "RepoParameterName";

        private readonly string[] _timeSpentFormats =
        {
            $@"m\{LogWork.Minutes}",
            $@"h\{LogWork.Hours}\ m\{LogWork.Minutes}",
            $@"h\{LogWork.Hours}"
        };

        private readonly IWorkLogService _workLogService;
        private IssueViewModel _issue;
        private ICommand _logCommand;
        private IRepo _repo;
        private TimeSpan _timeSpan;
        private string _timeSpent;

        public LogWorkPageViewModel(ILoader loader,
            IProgressService progressService,
            INavigationService navigationService,
            IWorkLogService workLogService)
            : base(loader, progressService, navigationService)
        {
            _workLogService = workLogService;

            Title = LogWork.Title;
        }

        public IssueViewModel Issue
        {
            get { return _issue; }
            private set { SetProperty(ref _issue, value); }
        }

        public string TimeSpent
        {
            get { return _timeSpent; }
            set
            {
                SetProperty(ref _timeSpent, value);
                OnPropertyChanged(() => IsTimeValid);
            }
        }

        public ICommand LogCommand =>
            _logCommand ?? (_logCommand = new DelegateCommand(Log));

        public bool IsTimeValid
            =>
                string.IsNullOrEmpty(TimeSpent) ||
                TimeSpan.TryParseExact(Regex.Replace(TimeSpent.ToLower().Trim(), @"\s+", " "), _timeSpentFormats,
                    CultureInfo.CurrentCulture, out _timeSpan);

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Issue = new IssueViewModel(parameters[IssueParameterName] as IIssue);
            _repo = parameters[RepoParameterName] as IRepo;
        }

        private async void Log()
        {
            await
                Loader.LoadAsync(
                    cancellationToken =>
                        _workLogService.LogTimeAsync(_repo.Path, Issue.Issue.Id, DateTime.Now, _timeSpan,
                            cancellationToken));
        }
    }
}