using System;
using System.Windows.Input;
using GiTracker.Helpers;
using GiTracker.Resources.Strings;
using GiTracker.Services.Device;
using GiTracker.Services.Progress;
using Prism.Commands;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class IssueDetailsViewModel : BaseViewModel
    {
        public const string IssueParameterName = "IssueParameterName";
        private readonly IDeviceService _deviceService;
        private IssueViewModel _issue;
        private ICommand _openInBrowserCommand;

        public IssueDetailsViewModel(IDeviceService deviceService, Loader loader, IProgressService progressService,
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

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Issue = parameters[IssueParameterName] as IssueViewModel;
            Title = string.Format(IssueDetails.IssueNumber, Issue?.Number);
        }

        private void OpenInBrowser() => _deviceService.OpenUri(new Uri(Issue?.WebPage));
    }
}