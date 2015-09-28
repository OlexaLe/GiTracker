using GiTracker.Services.DataLoader;
using GiTracker.Services.Progress;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class BaseListViewModel : BaseViewModel
    {
        private bool _isListLoading;

        public BaseListViewModel(ILoader loader, ILoader listLoader, IProgressService progressService,
            INavigationService navigationService) : base(loader, progressService, navigationService)
        {
            ListLoader = listLoader;
            ListLoader.LoadingChanged += (sender, args) => IsListLoading = ListLoader.IsLoading;
        }

        public bool IsListLoading
        {
            get { return _isListLoading; }
            private set { SetProperty(ref _isListLoading, value); }
        }

        protected ILoader ListLoader { get; }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            Loader.CancelLoading();
            ListLoader.CancelLoading();

            base.OnNavigatedFrom(parameters);
        }
    }
}