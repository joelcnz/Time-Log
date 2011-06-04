using System;
using NUnit.Framework;
using TimeLog.CommandHandlers;
using TimeLog.Commands;
using TimeLog.Infrastructure;

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

        [Test]
        public void RegisterCommandHandler_NothingYetRegistered_ShouldNotError()
        {
            // Act
            commandProcessor.RegisterCommandHandler(new FakeCommandHandler());

            // Assert
            Assert.Pass();
        }

        [Test]
        public void RegisterCommandHandler_SameHandlerTypeAlreadyRegistered_ShouldError()
        {
            // Arrange 
            commandProcessor.RegisterCommandHandler(new FakeCommandHandler());

            // Act & Assert
            Assert.Throws<InvalidOperationException>( () =>
                commandProcessor.RegisterCommandHandler(new FakeCommandHandler()));
        }


        [Test]
        public void RegisterCommandHandler_NullHandler_ShouldError()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                commandProcessor.RegisterCommandHandler(null));
        }

        public class FakeCommand : ICommand
        {
        }

        public class FakeCommandHandler : ICommandHandler
        {
            public ICommand HandleCommandLastCalledWith { get; set; }

            public bool CanHandleCommandsOfType(Type type)
            {
                return type == typeof (FakeCommand);
            }

            public void HandleCommand(ICommand command)
            {
                HandleCommandLastCalledWith = command;
            }
        }
    }
}