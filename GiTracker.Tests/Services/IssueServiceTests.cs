using System;
using System.Collections.Generic;
using System.Threading;
using GiTracker.Models;
using GiTracker.Services.Api;
using GiTracker.Services.Issues;
using GiTracker.Services.Rest;
using Moq;
using NUnit.Framework;

namespace GiTracker.Tests.Services
{
    [TestFixture]
    public class IssueServiceTests
    {
        [SetUp]
        public void Init()
        {
            var apiProviderMoq = new Mock<IGitApiProvider>();
            apiProviderMoq.Setup(moq => moq.GetIssuesRequest(It.IsAny<string>())).Returns(restRequest);

            _gitApiProvider = apiProviderMoq.Object;
        }

        private readonly RestRequest restRequest = new RestRequest();

        private const string RestServiceExceptionMessage = "RestServiceExceptionMessage";
        private IGitApiProvider _gitApiProvider;

        [Test]
        public async void GetIssuesCallsIRestService()
        {
            // Arrange
            var issuesList = new List<IIssue>();

            var restServiceMoq = new Mock<IRestService>();
            restServiceMoq.Setup(moq => moq.GetAsync(restRequest, It.IsAny<CancellationToken>()))
                .ReturnsAsync(issuesList);

            var issueService = new IssueService(restServiceMoq.Object, _gitApiProvider);

            // Act
            var issues = await issueService.GetIssuesAsync(It.IsAny<string>(), CancellationToken.None);

            // Assert
            Mock.Get(_gitApiProvider).Verify(moq => moq.GetIssuesRequest(It.IsAny<string>()), Times.Once);

            restServiceMoq.Verify(moq => moq.GetAsync(restRequest, It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.AreEqual(issues, issuesList);
        }

        [Test]
        [ExpectedException(typeof (Exception), ExpectedMessage = RestServiceExceptionMessage)]
        public async void GetIssuesDoesNotConsumeException()
        {
            // Arrange
            var restServiceMoq = new Mock<IRestService>();
            restServiceMoq.Setup(moq => moq.GetAsync(restRequest, It.IsAny<CancellationToken>()))
                .Throws(new Exception(RestServiceExceptionMessage));

            var issueService = new IssueService(restServiceMoq.Object, _gitApiProvider);

            // Act
            await issueService.GetIssuesAsync(It.IsAny<string>(), CancellationToken.None);

            // Assert
        }
    }
}