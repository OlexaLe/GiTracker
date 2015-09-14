using System.Threading.Tasks;
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
            Inactive = false;
        }

        public string Login
        {
            get { return _login; }
            set
            {
                SetProperty(ref _login, value);
                Inactive = CheckPosibilityOfLogin();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
                Inactive = CheckPosibilityOfLogin();
            }
        }

        public Command LoginCommand => _loginCommand ?? (_loginCommand = new Command(async () =>
        {
            Inactive = false;
            await DoLogin();
            Inactive = true;
        }, () => Inactive));

        private Task DoLogin()
        {
            return Loader.LoadAsync(async cancellationToken => { await _loginService.LoginAsync(Login, Password); });
        }

        private bool CheckPosibilityOfLogin() =>
            !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);

        protected override void ChangeCanExecute()
        {
            base.ChangeCanExecute();
            LoginCommand.ChangeCanExecute();
        }
    }
}