using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GiTracker.Models;
using GiTracker.Services.DataLoader;
using GiTracker.Services.Progress;
using GiTracker.Services.WorkLog;
using Prism.Commands;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class WorkLogsPageViewModel : BaseListViewModel
    {
        private readonly IWorkLogService _workLogService;
        private IIssue _issue;
        private IRepo _repo;
        private ICommand _updateReposCommand;
        private IEnumerable<WorkLogItem> _workLogs;

        public WorkLogsPageViewModel(ILoader loader,
            ILoader listLoader,
            IProgressService progressService,
            INavigationService navigationService,
            IWorkLogService workLogService)
            : base(loader, listLoader, progressService, navigationService)
        {
            _workLogService = workLogService;

            Title = Resources.Strings.WorkLogs.Title;
        }

        public IEnumerable<WorkLogItem> WorkLogs
        {
            get { return _workLogs; }
            set { SetProperty(ref _workLogs, value); }
        }

        public ICommand UpdateWorkLogsCommand =>
            _updateReposCommand ?? (_updateReposCommand = new DelegateCommand(UpdateWorkLogs));

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            _issue = parameters[Constants.IssueParameterName] as IIssue;
            _repo = parameters[Constants.RepoParameterName] as IRepo;

            Title = string.Format(Resources.Strings.WorkLogs.IssueTitle, _issue?.Number);

            await LoadWorkLogsAsync(Loader);
        }

        private Task LoadWorkLogsAsync(ILoader loader)
        {
            WorkLogs = null;

            return loader.LoadAsync(async cancellationToken =>
            {
                var logs =
                    await _workLogService.GetLogsAsync(_repo.Path, _issue.Number, cancellationToken);

                WorkLogs = logs;
            });
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            Loader.CancelLoading();

            base.OnNavigatedFrom(parameters);
        }

        private async void UpdateWorkLogs()
        {
            await LoadWorkLogsAsync(ListLoader);
        }
    }
}