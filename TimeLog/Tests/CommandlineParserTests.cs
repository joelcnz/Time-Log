using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TimeLog.Commands;

namespace TimeLog.Tests
{
    [TestFixture]
    public class CommandlineParserTests
    {
        private CommandlineParser commandlineParser;

        [SetUp]
        public void SetUp()
        {
            commandlineParser = new CommandlineParser();
        }

        [Test]
        public void EmptyCommand_ReturnsHelpCommand()
        {
            // Arrange

            // Act
            var command = commandlineParser.ParseCommandline("");

            // Assert
            Assert.That(command, Is.InstanceOf<HelpCommand>());
        }

        [Test]
        public void AddCommand_ReturnsAddCommand()
        {
            // Arrange

            // Act
            var command = commandlineParser.ParseCommandline(@"add ""task title""");

            // Assert
            Assert.That(command, Is.InstanceOf<AddCommand>());
        }

        [Test]
        public void AddCommand_ReturnsAddCommandWithTitle()
        {
            // Arrange

            // Act
            var command = commandlineParser.ParseCommandline(@"add ""my silly task""");

            // Assert
            var addCommand = command as AddCommand;
            Debug.Assert(addCommand != null);
            Assert.That(addCommand.TaskTitle, Is.EqualTo("my silly task"));
        }

        [Test]
        public void HelpCommand_ReturnsHelpCommand()
        {
            // Act
            var command = commandlineParser.ParseCommandline("h");

            // Assert
            Assert.That(command, Is.InstanceOf<HelpCommand>());
        }

        [Test]
        public void ViewCommand_ReturnsViewCOmmand()
        {
            // Act
            var command = commandlineParser.ParseCommandline("v");

            // Assert
            Assert.That(command, Is.InstanceOf<ViewCommand>());
        }

        [Test]
        public void QuitCommand_ReturnsQuitOmmand()
        {
            // Act
            var command = commandlineParser.ParseCommandline("q");

            // Assert
            Assert.That(command, Is.InstanceOf<QuitCommand>());
        }


        [Test]
        public void UnrecognisedCommand_Errors()
        {
            // Act & Assert
            Assert.Throws<InvalidCommandlineException>(() => commandlineParser.ParseCommandline("z"));
        }

    }
}
