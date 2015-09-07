using GiTracker.Resources.Strings;
using GiTracker.Services.DataLoader;
using GiTracker.ViewModels;
using NUnit.Framework;

namespace GiTracker.Tests.ViewModels
{
    [TestFixture]
    public class LogWorkPageViewModelTests
    {
        [Test]
        public void IsTimeValidReturnsFalseOn245m()
        {
            // Arrange
            var logWorkPageViewModel = new LogWorkPageViewModel(new Loader(null), null, null, null);

            // Act
            logWorkPageViewModel.TimeSpent = $"245{LogWork.Minutes}";

            // Assert
            Assert.IsFalse(logWorkPageViewModel.IsTimeValid);
        }

        [Test]
        public void IsTimeValidReturnsFalseOn3d()
        {
            // Arrange
            var logWorkPageViewModel = new LogWorkPageViewModel(new Loader(null), null, null, null);

            // Act
            logWorkPageViewModel.TimeSpent = "3d";

            // Assert
            Assert.IsFalse(logWorkPageViewModel.IsTimeValid);
        }

        [Test]
        public void IsTimeValidReturnsFalseOnMultipleValidHours()
        {
            // Arrange
            var logWorkPageViewModel = new LogWorkPageViewModel(new Loader(null), null, null, null);

            // Act
            logWorkPageViewModel.TimeSpent = $"40{LogWork.Hours} 35{LogWork.Hours}";

            // Assert
            Assert.IsFalse(logWorkPageViewModel.IsTimeValid);
        }

        [Test]
        public void IsTimeValidReturnsFalseOnMultipleValidMinutes()
        {
            // Arrange
            var logWorkPageViewModel = new LogWorkPageViewModel(new Loader(null), null, null, null);

            // Act
            logWorkPageViewModel.TimeSpent = $"40{LogWork.Minutes} 35{LogWork.Minutes}";

            // Assert
            Assert.IsFalse(logWorkPageViewModel.IsTimeValid);
        }

        [Test]
        public void IsTimeValidReturnsFalseOnMultipleValidValues()
        {
            // Arrange
            var logWorkPageViewModel = new LogWorkPageViewModel(new Loader(null), null, null, null);

            // Act
            logWorkPageViewModel.TimeSpent =
                $"2{LogWork.Hours} 40{LogWork.Minutes} 2{LogWork.Hours} 40{LogWork.Minutes}";

            // Assert
            Assert.IsFalse(logWorkPageViewModel.IsTimeValid);
        }

        [Test]
        public void IsTimeValidReturnsFalseOnRandomSet()
        {
            // Arrange
            var logWorkPageViewModel = new LogWorkPageViewModel(new Loader(null), null, null, null);

            // Act
            logWorkPageViewModel.TimeSpent = "d,bv kfdjvnlisueg nireug or";

            // Assert
            Assert.IsFalse(logWorkPageViewModel.IsTimeValid);
        }

        [Test]
        public void IsTimeValidReturnsTrueOn2h()
        {
            // Arrange
            var logWorkPageViewModel = new LogWorkPageViewModel(new Loader(null), null, null, null);

            // Act
            logWorkPageViewModel.TimeSpent = $"2{LogWork.Hours}";

            // Assert
            Assert.IsTrue(logWorkPageViewModel.IsTimeValid);
        }

        [Test]
        public void IsTimeValidReturnsTrueOn2h40m()
        {
            // Arrange
            var logWorkPageViewModel = new LogWorkPageViewModel(new Loader(null), null, null, null);

            // Act
            logWorkPageViewModel.TimeSpent = $"2{LogWork.Hours} 40{LogWork.Minutes}";

            // Assert
            Assert.IsTrue(logWorkPageViewModel.IsTimeValid);
        }

        [Test]
        public void IsTimeValidReturnsTrueOn2h40mWithSpaces()
        {
            // Arrange
            var logWorkPageViewModel = new LogWorkPageViewModel(new Loader(null), null, null, null);

            // Act
            logWorkPageViewModel.TimeSpent = $"   2{LogWork.Hours}   40{LogWork.Minutes}    ";

            // Assert
            Assert.IsTrue(logWorkPageViewModel.IsTimeValid);
        }

        [Test]
        public void IsTimeValidReturnsTrueOn2m()
        {
            // Arrange
            var logWorkPageViewModel = new LogWorkPageViewModel(new Loader(null), null, null, null);

            // Act
            logWorkPageViewModel.TimeSpent = $"2{LogWork.Minutes}";

            // Assert
            Assert.IsTrue(logWorkPageViewModel.IsTimeValid);
        }

        [Test]
        public void IsTimeValidReturnsTrueOn3h()
        {
            // Arrange
            var logWorkPageViewModel = new LogWorkPageViewModel(new Loader(null), null, null, null);

            // Act
            logWorkPageViewModel.TimeSpent = $"3{LogWork.Hours}";

            // Assert
            Assert.IsTrue(logWorkPageViewModel.IsTimeValid);
        }
    }
}