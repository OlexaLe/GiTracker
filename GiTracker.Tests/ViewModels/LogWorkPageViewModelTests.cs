using System;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;
using GiTracker.Resources.Strings;
using GiTracker.Services.DataLoader;
using GiTracker.Services.WorkLog;
using GiTracker.ViewModels;
using Moq;
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

        [Test]
        public async void WorkLogServiceIsCalledCorrectly()
        {
            // Arrange
            var wokrLogServiceMoq = new Mock<IWorkLogService>();
            wokrLogServiceMoq.Setup(
                moq =>
                    moq.LogTimeAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<TimeSpan>(),
                        It.IsAny<CancellationToken>())).Returns(Task.FromResult<IComment>(null));

            var loaderMoq = new Mock<ILoader>();
            loaderMoq.Setup(moq => moq.LoadAsync(It.IsAny<Func<CancellationToken, Task>>()))
                .Returns((Func<CancellationToken, Task> factory) => factory(It.IsAny<CancellationToken>()));

            const string timeSpent = "2h 20m";
            const int issueId = 5;
            const string repoPath = "test";
            var date = DateTime.Now.Date;
            var timeSpan = TimeSpan.FromMinutes(140);

            var viewModel = new LogWorkPageViewModel(loaderMoq.Object, null, null, wokrLogServiceMoq.Object);
            viewModel.TimeSpent = timeSpent;
            viewModel.Issue = new IssueViewModel(Mock.Of<IIssue>(issue => issue.Id == issueId));
            viewModel._repo = Mock.Of<IRepo>(repo => repo.Path == repoPath);
            viewModel.Date = date;

            // Act
            await viewModel.LogCommand.Execute();

            // Assert
            wokrLogServiceMoq.Verify(
                moq =>
                    moq.LogTimeAsync(repoPath, issueId, date, timeSpan,
                        It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}