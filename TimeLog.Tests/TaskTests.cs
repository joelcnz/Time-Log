using System;
using System.Collections.Generic;
using NUnit.Framework;
using TimeLog;

namespace TimeLog.Tests
{
    [TestFixture]
    public class TaskTests
    {
        [Test]
        public void ListOfTask_Sorted_ReordersByDate()
        {
            // Arrange
            var taskList = new List<Task>();

            taskList.Add(new Task(DateTime.Parse("2003/12/12")));
            taskList.Add(new Task(DateTime.Parse("2002/11/11")));

            // Act
            taskList.Sort();

            // Assert
            Assert.That(taskList[0].GetDateTime(), Is.LessThan(taskList[1].GetDateTime()));
        }
    }
}