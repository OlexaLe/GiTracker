using System;
using System.Threading.Tasks;
using GiTracker.Services.DataLoader;
using GiTracker.Services.Dialogs;
using Moq;
using NUnit.Framework;

namespace GiTracker.Tests.Services
{
    [TestFixture]
    public class LoaderTests
    {
        [Test]
        public async void CancelledTaskDoesNotShowDialog()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            dialogService.Setup(d => d.ShowMessageAsync(It.IsAny<string>()));

            var tcs = new TaskCompletionSource<object>();
            tcs.SetCanceled();

            var loader = new Loader(dialogService.Object);

            // Act
            await loader.LoadAsync(token => tcs.Task);

            // Assert
            dialogService.Verify(s => s.ShowMessageAsync(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public async void FailedTaskShowsDialog()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            dialogService.Setup(d => d.ShowMessageAsync(It.IsAny<string>())).Returns(Task.FromResult<object>(null));

            const string failedMessage = "Failed";
            var tcs = new TaskCompletionSource<object>();
            tcs.SetException(new Exception(failedMessage));

            var loader = new Loader(dialogService.Object);

            // Act
            await loader.LoadAsync(token => tcs.Task);

            // Assert
            dialogService.Verify(s => s.ShowMessageAsync(failedMessage), Times.Once);
        }

        [Test]
        public async void IsLoadingEventShouldTriggerTwice()
        {
            // Arrange
            var triggerCount = 0;
            var loader = new Loader(new Mock<IDialogService>().Object);
            loader.LoadingChanged += (sender, args) => ++triggerCount;

            // Act
            await loader.LoadAsync(token => Task.FromResult<object>(null));

            // Assert
            Assert.AreEqual(2, triggerCount);
        }
    }
}