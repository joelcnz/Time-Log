﻿using System;
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

        [Test]
        public void AddCommand_ReturnsAddCommand()
        {
            // Arrange

            // Act
            var command = commandlineParser.ParseCommandline("add");

            // Assert
            Assert.That(command.Root, Is.EqualTo("add"));
        }

        [Test]
        public void HelpCommand_ReturnsHelpCommand()
        {
            // Act
            var command = commandlineParser.ParseCommandline("h");

            // Assert
            Assert.That(command.Root, Is.EqualTo("h"));
        }

        [Test]
        public void ViewCommand_ReturnsViewCOmmand()
        {
            // Act
            var command = commandlineParser.ParseCommandline("v");

            // Assert
            Assert.That(command.Root, Is.EqualTo("v"));

        }

    }
}
