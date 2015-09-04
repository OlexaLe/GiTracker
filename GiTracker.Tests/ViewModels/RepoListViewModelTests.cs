using System;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;
using GiTracker.Services.DataLoader;
using GiTracker.Services.Progress;
using GiTracker.Services.Repos;
using GiTracker.ViewModels;
using Moq;
using NUnit.Framework;
using Prism.Navigation;

namespace GiTracker.Tests.ViewModels
{
    [TestFixture]
    public class RepoListViewModelTests
    {
        [SetUp]
        public void Init()
        {
            var repoServiceMoq = new Mock<IRepoService>();
            repoServiceMoq.Setup(moq => moq.GetReposAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(_repoList);
            _repoService = repoServiceMoq.Object;

            var loaderMoq = new Mock<ILoader>();
            loaderMoq.Setup(moq => moq.LoadAsync(It.IsAny<Func<CancellationToken, Task>>()))
                .Returns((Func<CancellationToken, Task> factory) => factory(It.IsAny<CancellationToken>()));
            _loader = loaderMoq.Object;

            var listLoaderMoq = new Mock<ILoader>();
            listLoaderMoq.Setup(moq => moq.LoadAsync(It.IsAny<Func<CancellationToken, Task>>()))
                .Returns((Func<CancellationToken, Task> factory) => factory(It.IsAny<CancellationToken>()));
            _listLoader = listLoaderMoq.Object;

            _progressService = Mock.Of<IProgressService>();

            _navigationService = Mock.Of<INavigationService>();
        }

        private IRepoService _repoService;
        private INavigationService _navigationService;
        private IProgressService _progressService;
        private ILoader _loader, _listLoader;
        private readonly IRepo[] _repoList = {Mock.Of<IRepo>(), Mock.Of<IRepo>(), Mock.Of<IRepo>()};

        [Test]
        public void CallsBaseLoaderWhenNavigated()
        {
            // Arrange
            var repoListViewModel = new RepoListPageViewModel(_loader, _listLoader, _progressService,
                _navigationService,
                _repoService);

            // Act
            repoListViewModel.OnNavigatedTo(null);

            // Assert
            Mock.Get(_loader).Verify(moq => moq.LoadAsync(It.IsAny<Func<CancellationToken, Task>>()), Times.Once);
            Mock.Get(_listLoader).Verify(moq => moq.LoadAsync(It.IsAny<Func<CancellationToken, Task>>()), Times.Never);
        }

        [Test]
        public async void CallsListLoaderWhenUpdatedByUser()
        {
            // Arrange
            var repoListViewModel = new RepoListPageViewModel(_loader, _listLoader, _progressService,
                _navigationService,
                _repoService);

            // Act
            await repoListViewModel.UpdateReposCommand.Execute();

            // Assert
            Mock.Get(_loader).Verify(moq => moq.LoadAsync(It.IsAny<Func<CancellationToken, Task>>()), Times.Never);
            Mock.Get(_listLoader).Verify(moq => moq.LoadAsync(It.IsAny<Func<CancellationToken, Task>>()), Times.Once);
        }

        [Test]
        public async void IssuesListIsNavigatedWithCorrectRepoParam()
        {
            // Arrange
            var repoListViewModel = new RepoListPageViewModel(_loader, _listLoader, _progressService,
                _navigationService,
                _repoService);
            var repo = Mock.Of<IRepo>(moq => moq.Name == "name" && moq.Path == "path");

            // Act
            await repoListViewModel.OpenRepoCommand.Execute(repo);

            // Assert
            Mock.Get(_navigationService).Verify(moq => moq.Navigate<IssueListPageViewModel>(
                new NavigationParameters {{IssueListPageViewModel.RepoParameterName, repo}}, false, true), Times.Once);
        }

        [Test]
        public void RepoListContainsAllReposLoaded()
        {
            // Arrange
            var repoListViewModel = new RepoListPageViewModel(_loader, _listLoader, _progressService,
                _navigationService,
                _repoService);

            // Act
            repoListViewModel.OnNavigatedTo(null);

            // Assert
            Assert.AreEqual(_repoList, repoListViewModel.Repos);
        }
    }
}