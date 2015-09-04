using System;
using System.Collections.Generic;
using System.Threading;
using GiTracker.Models;
using GiTracker.Services.Api;
using GiTracker.Services.Repos;
using GiTracker.Services.Rest;
using Moq;
using NUnit.Framework;

namespace GiTracker.Tests.Services
{
    [TestFixture]
    public class RepoServiceTests
    {
        [SetUp]
        public void Init()
        {
            var apiProviderMoq = new Mock<IGitApiProvider>();
            apiProviderMoq.Setup(moq => moq.GetUserRepositoriesRequest()).Returns(RepoRequest);
            _gitApiProvider = apiProviderMoq.Object;
        }

        private readonly RestRequest RepoRequest = new RestRequest();
        private string Host => "TestHost";
        private string ReposUrl => "TestUrl";
        private Type ReposListType => typeof (IEnumerable<IRepo>);
        private const string RestServiceExceptionMessage = "RestServiceExceptionMessage";
        private IGitApiProvider _gitApiProvider;

        [Test]
        public async void GetReposCallsIRestService()
        {
            // Arrange
            var repoList = new List<IRepo>();

            var restServiceMoq = new Mock<IRestService>();
            restServiceMoq.Setup(moq => moq.GetAsync(RepoRequest, It.IsAny<CancellationToken>()))
                .ReturnsAsync(repoList);

            var repoService = new RepoService(restServiceMoq.Object, _gitApiProvider);

            // Act
            var repos = await repoService.GetReposAsync(CancellationToken.None);

            restServiceMoq.Verify(moq => moq.GetAsync(RepoRequest, It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.AreEqual(repos, repoList);
        }

        [Test]
        [ExpectedException(typeof (Exception), ExpectedMessage = RestServiceExceptionMessage)]
        public async void GetReposDoesNotConsumeException()
        {
            // Arrange
            var restServiceMoq = new Mock<IRestService>();
            restServiceMoq.Setup(moq => moq.GetAsync(RepoRequest, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception(RestServiceExceptionMessage));

            var repoService = new RepoService(restServiceMoq.Object, _gitApiProvider);

            // Act
            await repoService.GetReposAsync(CancellationToken.None);

            // Assert
        }
    }
}