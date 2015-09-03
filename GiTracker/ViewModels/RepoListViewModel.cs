using GiTracker.Helpers;
using GiTracker.Resources.Strings;
using GiTracker.Services.Progress;
using GiTracker.Services.Repos;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    internal class RepoListViewModel : BaseListViewModel
    {
        private readonly IRepoService _repoService;

        public RepoListViewModel(Loader loader,
            Loader listLoader,
            IProgressService progressService,
            INavigationService navigationService,
            IRepoService repoService)
            : base(loader, listLoader, progressService, navigationService)
        {
            _repoService = repoService;

            Title = RepoList.Title;
        }
    }
}