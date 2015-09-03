using GiTracker.Helpers;
using GiTracker.Services.Progress;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    internal class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel(Loader loader, IProgressService progressService, INavigationService navigationService)
            : base(loader, progressService, navigationService)
        {
        }
    }
}