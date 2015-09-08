using System;
using GiTracker.Models;
using GiTracker.Services.WorkLog;
using Moq;
using NUnit.Framework;

namespace GiTracker.Tests.Services
{
    [TestFixture]
    public class WorkLogFormatHelperTests
    {
        [Test]
        public void GetCommentBodyWorksCorrectly()
        {
            // Arrange
            const string expectedLog = "2h 3m logged on 2/1/2015 via #GiTracker";

            var logDate = new DateTime(2015, 1, 2);
            var logTime = new TimeSpan(0, 2, 3, 4);

            // Act
            var actualLog = WorkLogFormatHelper.GetCommentBody(logDate, logTime);

            // Assert
            Assert.AreEqual(expectedLog, actualLog);
        }

        [Test]
        public void IsWorkLogReturnsFalseOnFreeText()
        {
            // Arrange
            const string log = "some time logged on 2/1/2015 via #GiTracker";
            var comment = Mock.Of<IComment>(moq => moq.Body == log);

            // Act
            var result = WorkLogFormatHelper.IsWorkLog(comment);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsWorkLogReturnsTrueOnWorkLog()
        {
            // Arrange
            const string log = "2h 3m logged on 2/1/2015 via #GiTracker";
            var comment = Mock.Of<IComment>(moq => moq.Body == log);

            // Act
            var result = WorkLogFormatHelper.IsWorkLog(comment);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void WorkLogIsParcedCorrectly()
        {
            // Arrange
            const string log = "5h 3m logged on 2/1/2015 via #GiTracker";
            var comment = Mock.Of<IComment>(moq => moq.Body == log);

            // Act
            var result = WorkLogFormatHelper.ExtractWorkLogItem(comment);

            // Assert
            Assert.AreEqual(new DateTime(2015, 1, 2), result.Date);
            Assert.AreEqual(TimeSpan.FromMinutes(303), result.Time);
        }
    }
}