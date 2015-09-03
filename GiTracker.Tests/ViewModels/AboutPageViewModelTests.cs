using System;
using GiTracker.Helpers;
using GiTracker.Services.Device;
using GiTracker.ViewModels;
using Moq;
using NUnit.Framework;

namespace GiTracker.Tests.ViewModels
{
    [TestFixture]
    public class AboutPageViewModelTests
    {
        [Test]
        public void EmailUsLeadsToCorrectEmail()
        {
            // Arrange
            var expectedUri = $"mailto:{Constants.XamarinGarageEmail}";
            Uri calledUri = null;
            var deviceService = new Mock<IDeviceService>();
            deviceService.Setup(d => d.OpenUri(It.IsAny<Uri>())).Callback<Uri>(uri => calledUri = uri);
            var vm = new AboutPageViewModel(deviceService.Object, new Loader(null), null, null);

            // Act
            vm.EmailUsCommand.Execute(null);

            // Assert
            Assert.AreEqual(expectedUri, calledUri.OriginalString);
        }
    }
}