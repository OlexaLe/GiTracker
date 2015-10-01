using System;
using System.Collections.Generic;
using System.Text;
using GiTracker.Services.Credential;
using GiTracker.Services.Settings;
using Moq;
using NUnit.Framework;

namespace GiTracker.Tests.Services
{
    [TestFixture]
    public class CredentialServiceTest
    {
        private readonly string _testName = "testname";
        private readonly string _testPassword = "testpassword";

        [Test]
        public void SetCredentialsGeneratesBasicAuthenticationToken()
        {
            // Arrange
            var basicAuthentication = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_testName}:{_testPassword}"));
            var credentialService = new CredentialsService(Mock.Of<ISettingsManager>());

            // Act
            credentialService.SetCredentials(_testName, _testPassword);

            // Assert
            Assert.AreEqual(credentialService.BasicAuthenticationToken, basicAuthentication);
        }

        [Test]
        public void StoreCredentialsCallsSettingsManagerAddSetting()
        {
            // Arrange
            var settings = new Dictionary<string, object>();
            var settingsManagerMoq = new Mock<ISettingsManager>();
            settingsManagerMoq.Setup(moq => moq.AddSetting(It.IsAny<string>(), It.IsAny<object>()))
                .Callback<string, object>((key, value) => settings[key] = value);
            settingsManagerMoq.Setup(moq => moq.RemoveSetting(It.IsAny<string>()))
                .Callback<string>(key => settings.Remove(key));
            var credentialService = new CredentialsService(settingsManagerMoq.Object);

            // Act
            credentialService.SetCredentials(_testName, _testPassword);
            credentialService.StoreCredentials();

            // Assert
            settingsManagerMoq.Verify(moq => moq.AddSetting(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
            Assert.IsTrue(settings.ContainsKey(CredentialsService.SessionSettingsKey));
        }
    }
}