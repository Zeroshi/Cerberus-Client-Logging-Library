using CerberusLogging.Classes;
using CerberusLogging.Classes.Enums;
using CerberusLogging.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class LoggingTests
    {
        private Logging _logger;
        private Mock<Logging> _mockLogger;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<Logging>("TestApp", LoggingDestination.Queue.Azure_Queue, LogLevel.Error,
                "connectionString", "TestQueueName");
            _logger = _mockLogger.Object;
        }

        [Test]
        public async void SendApplicationLogAsync_ValidApplicationMessage_LogInfoCreatedWithApplicationMessage()
        {
            // Arrange

            #region Metod to verify

            //_mockLogger.Verify(
            //    x => x.SendApplicationLogAsync(
            //        LogLevel.Information,
            //        It.IsAny<EventId>(),
            //        It.IsAny<It.IsAnyType>(),
            //        It.Is<Exception>(ex => ex == null),
            //        It.IsAny<Func<It.IsAnyType, Exception, string>>()
            //    ),
            //    Times.Once()
            //);

            #endregion
        }
    }
}