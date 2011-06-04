using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

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
        public void EmptyCommand_ReturnsNull()
        {
            // Arrange

            // Act
            var command = commandlineParser.ParseCommandline("");

            // Assert
            Assert.That(command, Is.Null);
        }

        [Test, Ignore("Not done yet")]
        public void AddCommand_ReturnsAddCommand()
        {
            // Arrange

            // Act
            var command = commandlineParser.ParseCommandline("a");

            // Assert
            Assert.That(command.Root, Is.EqualTo("add"));
        }
    }
}
