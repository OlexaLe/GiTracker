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
        public async void FailedTaskShouldShowDialog()
        {
            // Arrange
            const string failedMessage = "Failed";
            Func<Task> failedTask = () => { throw new Exception(failedMessage); };
            var dialogService = new Mock<IDialogService>();
            dialogService.Setup(d => d.ShowMessageAsync(It.IsAny<string>())).Returns(Task.FromResult<object>(null));
            var loader = new Loader(dialogService.Object);

            // Act
            await loader.LoadAsync(token => failedTask());

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