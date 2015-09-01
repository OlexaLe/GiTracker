using GiTracker.Helpers;
using GiTracker.Services.Progress;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public class BaseListViewModel : BaseViewModel
    {
        private bool _isListLoading;

        public BaseListViewModel(Loader loader, Loader listLoader, IProgressService progressService,
            INavigationService navigationService) : base(loader, progressService, navigationService)
        {
            ListLoader = listLoader;
            ListLoader.LoadinChanged += (sender, args) => IsListLoading = ListLoader.IsLoading;
        }

        public bool IsListLoading
        {
            get { return _isListLoading; }
            private set { SetProperty(ref _isListLoading, value); }
        }

        protected Loader ListLoader { get; }
    }
}