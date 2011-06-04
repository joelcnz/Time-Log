using System;
using NUnit.Framework;
using TimeLog.Infrastructure;

namespace TimeLog.Tests.Infrastructure
{
    [TestFixture]
    public class CommandHandlerTests
    {
        private FakeCommandHandler fakeCommandHandler;

        [SetUp]
        public void SetUp()
        {
            fakeCommandHandler = new FakeCommandHandler();    
        }

        [Test]
        public void HandleCommand_NullCommand_Errors()
        {
            Assert.Throws<ArgumentNullException>(() => fakeCommandHandler.HandleCommand(null));
        }

        [Test]
        public void HandleCommand_WrongCommandType_Errors()
        {
            Assert.Throws<ArgumentException>(() => fakeCommandHandler.HandleCommand(new OtherFakeCommand()));
        }

        [Test]
        public void HandleCommand_ValidCommand_CallsDoCommandOnSubclass()
        {
            // Arrange
            var fakeCommand = new FakeCommand();
   
            // Act
            fakeCommandHandler.HandleCommand(fakeCommand);

            // Assert
            Assert.That(fakeCommandHandler.DoHandleCommandLastCall, Is.SameAs(fakeCommand));
        }

        public class FakeCommand : ICommand
        {
        }

        public class OtherFakeCommand : ICommand {}

        public class FakeCommandHandler : CommandHandler<FakeCommand>
        {
            public FakeCommand DoHandleCommandLastCall { get; set; }

            protected override void DoHandleCommand(FakeCommand command)
            {
                DoHandleCommandLastCall = command;
            }
        }
    }
}