using GiTracker.Helpers;
using Prism.Mvvm;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public abstract class BaseViewModel : BindableBase, INavigationAware
    {
        protected readonly INavigationService NavigationService;
        private bool _isLoading;
        private string _title;

        protected BaseViewModel(Loader loader,
            INavigationService navigationService)
        {
            this.Loader = loader;
            this.Loader.LoadinChanged += (sender, args) => IsLoading = this.Loader.IsLoading;
            NavigationService = navigationService;
        }

        protected Loader Loader { get; }

        public bool IsLoading
        {
            get { return _isLoading; }
            protected set { SetProperty(ref _isLoading, value); }
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
    }
}