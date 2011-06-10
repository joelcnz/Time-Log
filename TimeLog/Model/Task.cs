//#in wrong class
//#This should not be here! List of tasks to choose from, and list of added tasks.
using System;

namespace TimeLog.Model
{
    //#date and time does not belong to task
    // task just has Id and Title
    public class Task : IComparable<DoingTask>
    {
        public string Title { get; private set; }

        public int Id { get; set; }

        //#should be Id, and title
        public Task(string title)
        {
            Title = title;
        }

        /// <summary>
        /// Get single task that is displayed in list of tasks for adding
        /// </summary>
        /// <returns>id and title</returns>
        public override string ToString()
        {
            return Id + " - " + Title;
        }
    }
}
