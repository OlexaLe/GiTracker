using GiTracker.Helpers;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class AboutPageViewModel : BaseViewModel
    {
        private string _version;

        public AboutPageViewModel(Loader loader, INavigationService navigationService) : base(loader, navigationService)
        {
            Version = "1.0";
        }

        public string Version
        {
            get { return _version; }
            set { SetProperty(ref _version, value); }
        }
    }
}