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
            var vm = new MainPageViewModel(null);
            var expectedScreen = typeof (IssueList);

            // Act

            // Assert
            Assert.AreEqual(expectedScreen, vm.PresentedViewModelType);
        }

        [Test]
        public async void PresentedViewModelTypeEventTriggeredOnRequest()
        {
            // Arrange
            var vm = new MainPageViewModel(null);
            var count = 0;
            const int expectedCount = 1;
            vm.PresentedViewModelTypeChanged += (sender, args) => count++;
            var newPageType = typeof (IssueDetailsViewModel);

            // Act
            await vm.SlideMenuItemTapped.Execute(new SlideMenuItem {ScreenView = newPageType});

            // Assert
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public async void PresentedViewModelTypeShouldChange()
        {
            // Arrange
            var vm = new MainPageViewModel(null);
            var newPageType = typeof (IssueDetailsViewModel);

            // Act
            await vm.SlideMenuItemTapped.Execute(new SlideMenuItem {ScreenView = newPageType});

            // Assert
            Assert.AreEqual(newPageType, vm.PresentedViewModelType);
        }
    }
}