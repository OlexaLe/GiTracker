using System.Collections.Generic;
using GiTracker.Services.Api;
using GiTracker.Services.Credential;
using Moq;
using NUnit.Framework;

namespace GiTracker.Tests.Services
{
    [TestFixture]
    public class GitHubProviderTest
    {
        private readonly string credentialKey = "TestCredential";
        private readonly string credentialValue = "TestCredentialValue";

        private Dictionary<string, string> Credential => new Dictionary<string, string>
        {
            {credentialKey, credentialValue}
        };

        [Test]
        public void CreateRequestCallICredentialService()
        {
            // Arrange
            var credentialMoq = new Mock<ICredentialService>();
            credentialMoq.Setup(moq => moq.Credential()).Returns(Credential);

            var apiProvider = new GitHubApiProvider(credentialMoq.Object);

            // Act
            var request = apiProvider.GetUserRequest();
            var headers = request.DefaultHeaders;

            // Assert
            credentialMoq.Verify(moq => moq.Credential(), Times.Once);
        }

        [Test]
        public void CreateRequestIsContainCredential()
        {
            // Arrange
            var credentialMoq = new Mock<ICredentialService>();
            credentialMoq.Setup(moq => moq.Credential()).Returns(Credential);

            var apiProvider = new GitHubApiProvider(credentialMoq.Object);

            // Act
            var request = apiProvider.GetUserRequest();

            // Assert
            Assert.IsTrue(request.DefaultHeaders.ContainsKey(credentialKey));
            Assert.IsTrue(request.DefaultHeaders.ContainsValue(credentialValue));
        }
    }
}