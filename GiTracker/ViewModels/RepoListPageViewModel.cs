using System.Collections.Generic;
using System.Threading.Tasks;
using GiTracker.Models;
using GiTracker.Resources.Strings;
using GiTracker.Services.DataLoader;
using GiTracker.Services.Progress;
using GiTracker.Services.Repos;
using Prism.Commands;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    internal class RepoListPageViewModel : BaseListViewModel
    {
        private readonly IRepoService _repoService;
        private DelegateCommand<IRepo> _openRepoCommand;
        private IEnumerable<IRepo> _repos;
        private DelegateCommand _updateReposCommand;

        public RepoListPageViewModel(ILoader loader,
            ILoader listLoader,
            IProgressService progressService,
            INavigationService navigationService,
            IRepoService repoService)
            : base(loader, listLoader, progressService, navigationService)
        {
            _repoService = repoService;

            Title = RepoList.Title;
        }

        public IEnumerable<IRepo> Repos
        {
            get { return _repos; }
            set
            {
                _repos = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand<IRepo> OpenRepoCommand =>
            _openRepoCommand ??
            (_openRepoCommand = new DelegateCommand<IRepo>(OpenRepo));

        public DelegateCommand UpdateReposCommand =>
            _updateReposCommand ?? (_updateReposCommand = new DelegateCommand(UpdateRepos));

        private async void UpdateRepos()
        {
            await LoadReposAsync(ListLoader);
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            await LoadReposAsync(Loader);
        }

        private Task LoadReposAsync(ILoader loader)
        {
            Repos = null;

            return loader.LoadAsync(async cancellationToken =>
            {
                var repos =
                    await _repoService.GetReposAsync(cancellationToken);

                Repos = repos;
            });
        }

        private void OpenRepo(IRepo repo)
        {
            NavigationService.Navigate<IssueListPageViewModel>(
                new NavigationParameters {{Constants.RepoParameterName, repo}}, false);
        }
    }
}