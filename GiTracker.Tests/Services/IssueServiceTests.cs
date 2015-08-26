using GiTracker.Models;
using GiTracker.Services.Api;
using GiTracker.Services.Issues;
using GiTracker.Services.Rest;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace GiTracker.Tests.Services
{
    [TestFixture]
    public class IssueServiceTests
    { 
        string Host => "TestHost";
        string IssuesUrl => "TestUrl";
        Type IssuesListType => typeof(IEnumerable<IIssue>);
        const string RestServiceExceptionMessage = "RestServiceExceptionMessage";

        IGitApiProvider _gitApiProvider;

        [SetUp]
        public void Init()
        {
            var apiProvderMoq = new Mock<IGitApiProvider>();
            apiProvderMoq.Setup(moq => moq.Host).Returns(Host);
            apiProvderMoq.Setup(moq => moq.GetIssuesUrl).Returns(IssuesUrl);
            apiProvderMoq.Setup(moq => moq.IssueListType).Returns(IssuesListType);

            _gitApiProvider = apiProvderMoq.Object;
        }

        [Test]
        public async void GetIssuesCallsIRestService()
        {
            // Arrange
            var issuesList = new List<IIssue>();
            
            var restServiceMoq = new Mock<IRestService>();
            restServiceMoq.Setup(moq => moq.GetAsync(Host, IssuesUrl, IssuesListType, It.IsAny<CancellationToken>()))
                .ReturnsAsync(issuesList);

            var issueService = new IssueService(restServiceMoq.Object, _gitApiProvider);

            // Act
            var issues = await issueService.GetIssuesAsync(CancellationToken.None);
            
            // Assert
            Mock.Get(_gitApiProvider).Verify(moq => moq.Host, Times.Once);
            Mock.Get(_gitApiProvider).Verify(moq => moq.GetIssuesUrl, Times.Once);
            Mock.Get(_gitApiProvider).Verify(moq => moq.IssueListType, Times.Once);

            restServiceMoq.Verify(moq => moq.GetAsync(Host, IssuesUrl, IssuesListType, It.IsAny<CancellationToken>()), Times.Once);

            Assert.AreEqual(issues, issuesList);
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = RestServiceExceptionMessage)]
        public async void GetIssuesDoesNotConsumeException()
        {
            // Arrange
            var restServiceMoq = new Mock<IRestService>();
            restServiceMoq.Setup(moq => moq.GetAsync(Host, IssuesUrl, IssuesListType, It.IsAny<CancellationToken>()))
                .Throws(new Exception(RestServiceExceptionMessage));

            var issueService = new IssueService(restServiceMoq.Object, _gitApiProvider);

            // Act
            await issueService.GetIssuesAsync(CancellationToken.None);

            // Assert
        }
    }
}
