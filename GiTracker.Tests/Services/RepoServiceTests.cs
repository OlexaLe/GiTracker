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
            apiProviderMoq.Setup(moq => moq.GetUserRepositoriesRequest()).Returns(_repoRequest);
            _gitApiProvider = apiProviderMoq.Object;
        }

        private readonly IRestRequest _repoRequest = Mock.Of<IRestRequest>();
        private const string RestServiceExceptionMessage = "RestServiceExceptionMessage";
        private IGitApiProvider _gitApiProvider;

        [Test]
        public async void GetReposCallsIRestService()
        {
            // Arrange
            var repoList = new List<IRepo>();

            var restServiceMoq = new Mock<IRestService>();
            restServiceMoq.Setup(moq => moq.GetAsync(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(repoList);

            var repoService = new RepoService(restServiceMoq.Object, _gitApiProvider);

            // Act
            var repos = await repoService.GetReposAsync(CancellationToken.None);

            // Assert
            restServiceMoq.Verify(moq => moq.GetAsync(_repoRequest, It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.AreEqual(repos, repoList);
        }

        [Test]
        [ExpectedException(typeof (Exception), ExpectedMessage = RestServiceExceptionMessage)]
        public async void GetReposDoesNotConsumeException()
        {
            // Arrange
            var restServiceMoq = new Mock<IRestService>();
            restServiceMoq.Setup(moq => moq.GetAsync(_repoRequest, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception(RestServiceExceptionMessage));

            var repoService = new RepoService(restServiceMoq.Object, _gitApiProvider);

            // Act
            await repoService.GetReposAsync(CancellationToken.None);

            // Assert
        }
    }
}