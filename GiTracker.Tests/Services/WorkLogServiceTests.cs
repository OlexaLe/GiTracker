using System;
using System.Collections.Generic;
using System.Threading;
using GiTracker.Models.GitHub;
using GiTracker.Services.Api;
using GiTracker.Services.Rest;
using GiTracker.Services.WorkLog;
using Moq;
using NUnit.Framework;

namespace GiTracker.Tests.Services
{
    [TestFixture]
    public class WorkLogServiceTests
    {
        [SetUp]
        public void Init()
        {
            var apiProviderMoq = new Mock<IGitApiProvider>();
            apiProviderMoq.Setup(moq => moq.GetCreateCommentRequest(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(_restRequest);

            _gitApiProvider = apiProviderMoq.Object;
        }

        private readonly IRestRequest _restRequest = Mock.Of<IRestRequest>();
        private IGitApiProvider _gitApiProvider;

        [Test]
        public async void LogTimeFormat()
        {
            // Arrange
            var expectedLog = new Dictionary<string, string> {{"body", "2h 3m logged on 2/1/2015 via #GiTracker"}};
            object actualLog = null;

            var restMoq = new Mock<IRestService>();
            restMoq.Setup(r => r.PostAsync(It.IsAny<IRestRequest>(), It.IsAny<object>(),
                It.IsAny<CancellationToken>()))
                .Callback<IRestRequest, object, CancellationToken>((request, body, token) => { actualLog = body; })
                .ReturnsAsync(new GitHubComment());

            var workLogService = new WorkLogService(restMoq.Object, _gitApiProvider);
            var logDate = new DateTime(2015, 1, 2);
            var logTime = new TimeSpan(0, 2, 3, 4);


            // Act
            await workLogService.LogTimeAsync("test", 42, logDate, logTime, CancellationToken.None);

            // Assert
            var actualDictionary = (Dictionary<string, string>) actualLog;
            Assert.AreEqual(expectedLog, actualDictionary);
        }
    }
}