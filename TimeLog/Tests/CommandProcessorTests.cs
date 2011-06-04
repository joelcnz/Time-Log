using System;
using NUnit.Framework;
using TimeLog.CommandHandlers;
using TimeLog.Commands;

namespace TimeLog.Tests
{
    [TestFixture]
    public class CommandProcessorTests
    {
        private CommandProcessor commandProcessor;

        [SetUp]
        public void SetUp()
        {
            commandProcessor = new CommandProcessor();
        }

        [Test]
        public void ProcessCommand_NoHandlersRegistered_ShouldError()
        {
            // Arrange
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => commandProcessor.ProcessCommand(new FakeCommand()));
        }

        [Test]
        public void ProcessCommand_HandlerRegisteredForCommand_ShouldCallHandlerWithCommand()
        {
            // Arrange
            var fakeCommand = new FakeCommand();
            var fakeCommandHandler = new FakeCommandHandler();
            commandProcessor.RegisterCommandHandler(fakeCommandHandler);

            // Act
            commandProcessor.ProcessCommand(fakeCommand);

            // Assert
            Assert.That(fakeCommandHandler.HandleCommandLastCalledWith, Is.SameAs(fakeCommand));
        }

        [Test]
        public void ProcessCommand_NullCommand_Errors()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => commandProcessor.ProcessCommand(null));
        }

        public class FakeCommand : ICommand
        {
        }

        public class FakeCommandHandler : CommandHandler<FakeCommand>
        {
            public ICommand HandleCommandLastCalledWith { get; set; }

            public override void HandleCommand(ICommand command)
            {
                HandleCommandLastCalledWith = command;
            }
        }
    }
}