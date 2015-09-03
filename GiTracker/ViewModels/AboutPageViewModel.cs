using System;
using GiTracker.Helpers;
using GiTracker.Services.Device;
using Prism.Navigation;
using Xamarin.Forms;

namespace GiTracker.ViewModels
{
    public class AboutPageViewModel : BaseViewModel
    {
        private readonly IDeviceService _deviceService;
        private Command _emailUsCommand;
        private string _version;

        public AboutPageViewModel(IDeviceService deviceService, Loader loader, INavigationService navigationService)
            : base(loader, navigationService)
        {
            _deviceService = deviceService;
            Version = "1.0";
        }

        public string Version
        {
            get { return _version; }
            set { SetProperty(ref _version, value); }
        }

        public Command EmailUsCommand => _emailUsCommand ?? (_emailUsCommand = new Command(DoEmailUs));

        private void DoEmailUs()
        {
            _deviceService.OpenUri(new Uri("mailto:" + Constants.XamarinGarageEmail));
        }
    }
}