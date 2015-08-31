using GiTracker.Helpers;
using GiTracker.Services.Progress;
using Prism.Mvvm;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public abstract class BaseViewModel : BindableBase, INavigationAware
    {
        private readonly IProgressService _progressService;
        protected readonly INavigationService NavigationService;
        private bool _isLoading;
        private string _title;

        protected BaseViewModel(Loader loader, IProgressService progressService,
            INavigationService navigationService)
        {
            Loader = loader;
            Loader.LoadinChanged += (sender, args) => IsLoadingChanged(Loader.IsLoading);
            _progressService = progressService;
            NavigationService = navigationService;
        }

        protected Loader Loader { get; }

        public bool IsLoading
        {
            get { return _isLoading; }
            private set { SetProperty(ref _isLoading, value); }
        }

        public string Title
        {
            get { return _title; }
            protected set { SetProperty(ref _title, value); }
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        private void IsLoadingChanged(bool isLoading)
        {
            IsLoading = isLoading;
            if (isLoading)
            {
                _progressService.ShowProgress();
            }
            else
            {
                _progressService.DismissProgress();
            }
        }
    }
}