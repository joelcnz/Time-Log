using System.Linq;
using NUnit.Framework;
using TimeLog.CommandHandlers;
using TimeLog.Commands;
using TimeLog.Model;

namespace TimeLog.Tests.CommandHandlers
{
    [TestFixture]
    public class AddCommandHandlerTests
    {
        [Test]
        public void HandleCommand_ShouldAddTaskToRepository()
        {
            // Arrange
            var taskRepository = new InMemoryTaskRepository();

            var addCommandHandler = new AddCommandHandler(taskRepository);

            // Act
            addCommandHandler.HandleCommand(new AddCommand("tasktitle"));

            // Assert
            Assert.That(taskRepository.GetAll(), Is.Not.Empty);
        }

        [Test]
        public void HandleCommand_ShouldAddTaskWithTitle()
        {
            // Arrange
            const string taskTitle = "tasktitle";

            var taskRepository = new InMemoryTaskRepository();

            var addCommandHandler = new AddCommandHandler(taskRepository);

            // Act
            addCommandHandler.HandleCommand(new AddCommand(taskTitle));

            // Assert
            Assert.That(taskRepository.GetAll().First().Title, Is.EqualTo(taskTitle));
        }

        [Test]
        public void HandleCommand_NoExistingTasksShouldAddTaskNumberOne()
        {
            // Arrange
            const string taskTitle = "tasktitle";

            var taskRepository = new InMemoryTaskRepository();

            var addCommandHandler = new AddCommandHandler(taskRepository);

            // Act
            addCommandHandler.HandleCommand(new AddCommand(taskTitle));

            // Assert
            Assert.That(taskRepository.GetAll().Last().Number, Is.EqualTo(1));
        }

        [Test]
        public void HandleCommand_HaveExistingTasksShouldAddHighestTaskNumberPlusOne()
        {
            // Arrange
            const string taskTitle = "tasktitle";

            var taskRepository = new InMemoryTaskRepository();
            taskRepository.Add(new Task(123));

            var addCommandHandler = new AddCommandHandler(taskRepository);

            // Act
            addCommandHandler.HandleCommand(new AddCommand(taskTitle));

            // Assert
            Assert.That(taskRepository.GetAll().Last().Number, Is.EqualTo(124));
        }
    }
}