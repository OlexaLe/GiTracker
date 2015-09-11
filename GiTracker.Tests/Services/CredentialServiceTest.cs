using System;
using System.Collections.Generic;
using System.Text;
using GiTracker.Services.Credential;
using NUnit.Framework;

namespace GiTracker.Tests.Services
{
    [TestFixture]
    public class CredentialServiceTest
    {
        private readonly string _testName = "testname";
        private readonly string _testPassword = "testpassword";

        [Test]
        public void CheckingBase64Credential()
        {
            // Arrange
            var credentialService = new CredentialService();
            var plainTextBytes = Encoding.UTF8.GetBytes($"{_testName}:{_testPassword}");
            var basicAuthentication = Convert.ToBase64String(plainTextBytes);
            credentialService.SetBasicCredential(_testName, _testPassword);

            // Act
            var credential = credentialService.Credential();

            // Assert
            Assert.AreEqual(credential,
                new Dictionary<string, string> {{"Authorization", $"Basic {basicAuthentication}"}});
        }
    }
}