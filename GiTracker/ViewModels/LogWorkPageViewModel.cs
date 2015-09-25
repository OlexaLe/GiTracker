using System;
using System.Globalization;
using System.Text.RegularExpressions;
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
        private readonly string[] _timeSpentFormats =
        {
            $@"m\{LogWork.Minutes}",
            $@"h\{LogWork.Hours}\ m\{LogWork.Minutes}",
            $@"h\{LogWork.Hours}"
        };

        private readonly IWorkLogService _workLogService;
        private DateTime _date;
        private IssueViewModel _issue;
        private DelegateCommand _logCommand;
        internal IRepo _repo;
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
            Date = DateTime.Now;
        }

        public IssueViewModel Issue
        {
            get { return _issue; }
            internal set { SetProperty(ref _issue, value); }
        }

        public string TimeSpent
        {
            get { return _timeSpent; }
            set
            {
                SetProperty(ref _timeSpent, value);
                OnPropertyChanged(() => IsTimeValid);
                LogCommand.RaiseCanExecuteChanged();
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public DelegateCommand LogCommand =>
            _logCommand ??
            (_logCommand = new DelegateCommand(Log, () => IsTimeValid));

        public bool IsTimeValid
            =>
                !string.IsNullOrEmpty(TimeSpent) &&
                TimeSpan.TryParseExact(Regex.Replace(TimeSpent.ToLower().Trim(), @"\s+", " "), _timeSpentFormats,
                    CultureInfo.CurrentCulture, out _timeSpan);

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Issue = new IssueViewModel(parameters[Constants.IssueParameterName] as IIssue);
            _repo = parameters[Constants.RepoParameterName] as IRepo;

            Title = string.Format(LogWork.IssueTitle, Issue.Number);
        }

        private async void Log()
        {
            if (!LogCommand.CanExecute()) return;

            await
                Loader.LoadAsync(
                    cancellationToken =>
                        _workLogService.LogTimeAsync(_repo.Path, Issue.Issue.Number, Date, _timeSpan,
                            cancellationToken));
        }
    }
}