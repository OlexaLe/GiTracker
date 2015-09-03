using GiTracker.Services.DataLoader;
using GiTracker.Services.Progress;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    internal class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel(ILoader loader, IProgressService progressService, INavigationService navigationService)
            : base(loader, progressService, navigationService)
        {
        }
    }
}