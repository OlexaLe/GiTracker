using System;
using GiTracker.Helpers;
using GiTracker.Models;
using GiTracker.Services.Device;
using GiTracker.ViewModels;
using Moq;
using NUnit.Framework;

namespace GiTracker.Tests.ViewModels
{
    [TestFixture]
    public class IssueDetailsViewModelTests
    {
        [Test]
        public void OpenInBrowserWork()
        {
            // Arrange
            var expectedIssuePage = "http://www.apple.com";
            Uri calledUri = null;
            var deviceService = new Mock<IDeviceService>();
            deviceService.Setup(d => d.OpenUri(It.IsAny<Uri>())).Callback<Uri>(uri => calledUri = uri);
            var vm = new IssueDetailsViewModel(deviceService.Object, new Loader(null), null, null);

            var issue = new IssueViewModel(new GitHubIssue {WebPage = expectedIssuePage});
            vm.Issue = issue;

            // Act
            vm.OpenInBrowserCommand.Execute(null);

            // Assert
            Assert.AreEqual(expectedIssuePage, calledUri.OriginalString);
        }

        [Test]
        public void ViewModelInitializesCorrectly()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}