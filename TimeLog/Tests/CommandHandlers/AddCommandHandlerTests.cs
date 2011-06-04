using NUnit.Framework;
using TimeLog.CommandHandlers;
using TimeLog.Commands;
using TimeLog.Model;

namespace TimeLog.Tests.CommandHandlerTests
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
            addCommandHandler.HandleCommand(new AddCommand());

            // Assert
            Assert.That(taskRepository.GetAll(), Is.Not.Empty);
        }
    }
}