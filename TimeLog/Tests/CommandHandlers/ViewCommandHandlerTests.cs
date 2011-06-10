using System;
using System.IO;
using NUnit.Framework;
using TimeLog.CommandHandlers;
using TimeLog.Commands;
using TimeLog.Model;

namespace TimeLog.Tests.CommandHandlers
{
    [TestFixture]
    public class ViewCommandHandlerTests
    {
        [Test]
        public void HandleCommand_OneTask_OutputsOneTaskToWriter()
        {
            // Arrange
            const string title1 = "fwef";
            const string title2 = "fwefewf";
            var taskRepository = new InMemoryTaskRepository();
            taskRepository.Add(new Task(123, title1));
            taskRepository.Add(new Task(456, title2));

            var stringWriter = new StringWriter();
            var viewCommandHandler = new ViewCommandHandler(taskRepository, stringWriter);

            // Act
            viewCommandHandler.HandleCommand(new ViewCommand());

            // Assert
            var textOutput = stringWriter.GetStringBuilder().ToString();
            Assert.That(textOutput, Is.StringContaining("123"));
            Assert.That(textOutput, Is.StringContaining("456"));
            Assert.That(textOutput, Is.StringContaining(title1));
            Assert.That(textOutput, Is.StringContaining(title2));
        }
    }
}