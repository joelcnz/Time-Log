using System.Collections.Generic;

namespace TimeLog.Model
{
    public class Task
    {
        public int Number { get; private set; }

        public string Title { get; set; }

        public IList<DoingTask> TaskDoings { get; private set; }

        public Task(int number)
        {
            Number = number;
        }

        public Task(int number, string title)
        {
            Number = number;
            Title = title;
        }

        /// <summary>
        /// Get single task that is displayed in list of tasks for adding
        /// </summary>
        /// <returns>id and title</returns>
        public override string ToString()
        {
            return Number + " - " + Title;
        }
    }
}
