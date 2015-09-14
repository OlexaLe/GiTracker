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
            var credentialMoq = new Mock<ICredentialService>();
            credentialMoq.Setup(moq => moq.Credential()).Returns(Credential);

            var apiProvider = new GitHubApiProvider(credentialMoq.Object);
            apiProvider.GetUserRequest();

            credentialMoq.Verify(moq => moq.Credential(), Times.Once);
        }

        [Test]
        public void CreateRequestIsContainCredential()
        {
            var credentialMoq = new Mock<ICredentialService>();
            credentialMoq.Setup(moq => moq.Credential()).Returns(Credential);

            var apiProvider = new GitHubApiProvider(credentialMoq.Object);
            var request = apiProvider.GetUserRequest();

            Assert.IsTrue(request.DefaultHeaders.ContainsKey(credentialKey));
            Assert.IsTrue(request.DefaultHeaders.ContainsValue(credentialValue));
        }
    }
}