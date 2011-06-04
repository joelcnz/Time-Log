using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using TimeLog.CommandHandlers;
using TimeLog.Commands;
using TimeLog.Model;

namespace TimeLog.Tests.CommandHandlerTests
{
    [TestFixture]
    public class ViewCommandHandlerTests
    {
        [Test]
        public void HandleCommand_OneTask_OutputsOneTaskToWriter()
        {
            // Arrange
            var taskRepository = new TaskRepository();
            taskRepository.Add(new Task(DateTime.Parse("2003/12/12")));
            taskRepository.Add(new Task(DateTime.Parse("2004/12/12")));

            var stringWriter = new StringWriter();
            var viewCommandHandler = new ViewCommandHandler(taskRepository, stringWriter);

            // Act
            viewCommandHandler.HandleCommand(new ViewCommand());

            // Assert
            var textOutput = stringWriter.GetStringBuilder().ToString();
            Assert.That(textOutput, Is.StringContaining("2003"));
            Assert.That(textOutput, Is.StringContaining("2004"));
        }
    }
}