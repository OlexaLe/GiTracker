using GiTracker.Services.DataLoader;
using GiTracker.Services.Login;
using GiTracker.Services.Progress;
using Prism.Navigation;
using Xamarin.Forms;

namespace GiTracker.ViewModels
{
    internal class LoginPageViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;
        private string _login;
        private Command _loginCommand;
        private string _password;

        public LoginPageViewModel(ILoader loader,
            IProgressService progressService,
            INavigationService navigationService,
            ILoginService loginService)
            : base(loader, progressService, navigationService)
        {
            _loginService = loginService;
        }

        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public Command LoginCommand => _loginCommand ?? (_loginCommand = new Command(DoLogin));

        private async void DoLogin()
        {
            await Loader.LoadAsync(async cancellationToken => { await _loginService.LoginAsync(Login, Password); });
        }
    }
}