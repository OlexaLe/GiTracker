using GiTracker.Events;
using GiTracker.Services.DataLoader;
using GiTracker.Services.Login;
using GiTracker.Services.Progress;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    internal class LoginPageViewModel : BaseViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ILoginService _loginService;
        private string _login;
        private DelegateCommand _loginCommand;
        private string _password;

        public LoginPageViewModel(ILoader loader,
            IProgressService progressService,
            INavigationService navigationService,
            ILoginService loginService,
            IEventAggregator eventAggregator)
            : base(loader, progressService, navigationService)
        {
            Loader.LoadingChanged += (sender, args) => LoginCommand.RaiseCanExecuteChanged();
            _loginService = loginService;
            _eventAggregator = eventAggregator;
        }

        public string Login
        {
            get { return _login; }
            set
            {
                SetProperty(ref _login, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand LoginCommand
            =>
                _loginCommand ??
                (_loginCommand =
                    new DelegateCommand(DoLogin,
                        () => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password) && !Loader.IsLoading));

        private async void DoLogin()
        {
            await Loader.LoadAsync(async cancellationToken =>
            {
                await _loginService.LoginAsync(Login, Password, cancellationToken);
                _eventAggregator.GetEvent<LoginEvent>().Publish(null);
            });
        }
    }
}