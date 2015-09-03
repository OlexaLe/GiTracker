using System;
using GiTracker.Helpers;
using Prism.Navigation;
using Xamarin.Forms;

namespace GiTracker.ViewModels
{
    public class AboutPageViewModel : BaseViewModel
    {
        private Command _emailUsCommand;
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

        public Command EmailUsCommand
        {
            get { return _emailUsCommand ?? (_emailUsCommand = new Command(DoEmailUs)); }
        }

        private void DoEmailUs()
        {
            Device.OpenUri(new Uri("mailto:" + Constants.XamarinGarageEmail));
        }
    }
}