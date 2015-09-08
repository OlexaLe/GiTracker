using System;
using GiTracker.Models;
using GiTracker.Models.GitHub;
using GiTracker.Resources.Strings;
using GiTracker.Services.DataLoader;
using GiTracker.Services.Device;
using GiTracker.ViewModels;
using Moq;
using NUnit.Framework;
using Prism.Navigation;

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
            var vm = new IssueDetailsPageViewModel(deviceService.Object, new Loader(null), null, null);

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
            const int expectedIssueNumber = 42;
            const string expectedRepoPath = "test";
            var expectedPageTitle = string.Format(IssueDetails.IssueNumber, expectedIssueNumber);
            var vm = new IssueDetailsPageViewModel(null, new Loader(null), null, null);
            var issue = Mock.Of<IIssue>(moq => moq.Number == expectedIssueNumber);
            var repo = Mock.Of<IRepo>(moq => moq.Path == expectedRepoPath);
            var parameters = new NavigationParameters
            {
                {IssueDetailsPageViewModel.IssueParameterName, issue},
                {IssueDetailsPageViewModel.RepoParameterName, repo}
            };

            // Act
            vm.OnNavigatedTo(parameters);

            // Assert
            Assert.AreEqual(expectedIssueNumber, vm.Issue.Number);
            Assert.AreEqual(expectedPageTitle, vm.Title);
        }
    }
}