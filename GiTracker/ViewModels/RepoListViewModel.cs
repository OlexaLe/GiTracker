using GiTracker.Helpers;
using GiTracker.Resources.Strings;
using GiTracker.Services.Progress;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    internal class RepoListViewModel : BaseListViewModel
    {
        public RepoListViewModel(Loader loader,
            Loader listLoader,
            IProgressService progressService,
            INavigationService navigationService)
            : base(loader, listLoader, progressService, navigationService)
        {
            Title = RepoList.Title;
        }
    }
}