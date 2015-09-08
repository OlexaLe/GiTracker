using GiTracker.Models;
using GiTracker.Resources.Strings;
using GiTracker.Services.DataLoader;
using GiTracker.Services.Progress;
using GiTracker.Services.WorkLog;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class WorkLogsPageViewModel : BaseViewModel
    {
        private readonly IWorkLogService _workLogService;
        private IIssue _issue;
        private IRepo _repo;

        public WorkLogsPageViewModel(ILoader loader,
            IProgressService progressService,
            INavigationService navigationService,
            IWorkLogService workLogService)
            : base(loader, progressService, navigationService)
        {
            _workLogService = workLogService;

            Title = WorkLogs.Title;
        }
    }
}