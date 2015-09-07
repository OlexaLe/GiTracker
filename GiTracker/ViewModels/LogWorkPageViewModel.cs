using GiTracker.Services.DataLoader;
using GiTracker.Services.Progress;
using GiTracker.Services.WorkLog;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class LogWorkPageViewModel : BaseViewModel
    {
        private readonly IWorkLogService _workLogService;

        public LogWorkPageViewModel(ILoader loader,
            IProgressService progressService,
            INavigationService navigationService,
            IWorkLogService workLogService)
            : base(loader, progressService, navigationService)
        {
            _workLogService = workLogService;
        }
    }
}