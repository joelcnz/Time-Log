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
            taskRepository.Add(new Task(title1, DateTime.Parse("2003/12/12")));
            taskRepository.Add(new Task(title2, DateTime.Parse("2004/12/12")));

            var stringWriter = new StringWriter();
            var viewCommandHandler = new ViewCommandHandler(taskRepository, stringWriter);

            // Act
            viewCommandHandler.HandleCommand(new ViewCommand());

            // Assert
            var textOutput = stringWriter.GetStringBuilder().ToString();
            Assert.That(textOutput, Is.StringContaining("2003"));
            Assert.That(textOutput, Is.StringContaining("2004"));
            Assert.That(textOutput, Is.StringContaining(title1));
            Assert.That(textOutput, Is.StringContaining(title2));
        }
    }
}