using GiTracker.Models;
using GiTracker.ViewModels;
using GiTracker.Views;
using NUnit.Framework;

namespace GiTracker.Tests.ViewModels
{
    [TestFixture]
    public class MainPageViewModelTests
    {
        [Test]
        public void DefaultPresentedViewModelTypeIsIssueList()
        {
            // Arrange
            var vm = new MainPageViewModel(null, null);
            var expectedScreen = typeof (RepoListPage);

            // Act

            // Assert
            Assert.AreEqual(expectedScreen, vm.PresentedViewModelType);
        }

        [Test]
        public async void PresentedViewModelTypeEventTriggeredOnRequest()
        {
            // Arrange
            var vm = new MainPageViewModel(null, null);
            var count = 0;
            const int expectedCount = 1;
            vm.PresentedViewModelTypeChanged += (sender, args) => count++;
            var newPageType = typeof (IssueDetailsPageViewModel);

            // Act
            await vm.SlideMenuItemTapped.Execute(new SlideMenuItem {ScreenView = newPageType});

            // Assert
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public async void PresentedViewModelTypeShouldChange()
        {
            // Arrange
            var vm = new MainPageViewModel(null, null);
            var newPageType = typeof (IssueDetailsPageViewModel);

            // Act
            await vm.SlideMenuItemTapped.Execute(new SlideMenuItem {ScreenView = newPageType});

            // Assert
            Assert.AreEqual(newPageType, vm.PresentedViewModelType);
        }
    }
}