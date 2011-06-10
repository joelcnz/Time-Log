using System;
using System.Collections.Generic;
using NUnit.Framework;
using TimeLog.Model;

namespace TimeLog.Tests.Model
{
    [TestFixture]
    public class DoingTaskTests
    {
        [Test]
        public void ListOfTask_Sorted_ReordersByDate()
        {
            // Arrange
            var task = new Task(123);

            var doingTasks = new List<DoingTask>();

            doingTasks.Add(new DoingTask(task, DateTime.Parse("2003/12/10")));
            doingTasks.Add(new DoingTask(task, DateTime.Parse("2002/11/11")));

            // Act
            doingTasks.Sort();

            // Assert
            Assert.That(doingTasks[0].DateTime, Is.LessThan(doingTasks[1].DateTime));
        }
    }
}