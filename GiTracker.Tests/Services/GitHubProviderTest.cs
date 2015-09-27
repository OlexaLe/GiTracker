using System.Linq;
using GiTracker.Services.Api;
using GiTracker.Services.Credential;
using Moq;
using NUnit.Framework;

namespace GiTracker.Tests.Services
{
    [TestFixture]
    public class GitHubProviderTest
    {
        [SetUp]
        public void SetUp()
        {
            _credentialsServiceMoq = new Mock<ICredentialsService>();
            _credentialsServiceMoq.Setup(moq => moq.BasicAuthenticationToken).Returns(_basicAuthenticationToken);
        }

        private readonly string _basicAuthenticationToken = "TestBasicAuthenticationToken";

        private Mock<ICredentialsService> _credentialsServiceMoq;

        [Test]
        public void CreateRequestCallsICredentialsServiceBasicAuthenticationToken()
        {
            // Arrange
            var apiProvider = new GitHubApiProvider(_credentialsServiceMoq.Object);

            // Act
            var request = apiProvider.GetUserRequest();
            var headers = request.DefaultHeaders;

            // Assert
            _credentialsServiceMoq.Verify(moq => moq.BasicAuthenticationToken, Times.AtLeastOnce);
        }

        [Test]
        public void CreateRequestIsContainCredential()
        {
            // Arrange
            var apiProvider = new GitHubApiProvider(_credentialsServiceMoq.Object);

            // Act
            var request = apiProvider.GetUserRequest();

            // Assert
            Assert.IsTrue(request.DefaultHeaders.Values.Any(value => value.Contains(_basicAuthenticationToken)));
        }
    }
}