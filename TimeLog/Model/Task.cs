//#in wrong class
//#This should not be here! List of tasks to choose from, and list of added tasks.
using System;

namespace TimeLog.Model
{
    //#date and time does not belong to task
    // task just has Id and Title
    public class Task : IComparable<Task>
    {
        //#in wrong class
        private Period period;
        public string Title { get; private set; }
        //#in wrong class
        public DateTime DateTime { get; private set; }
        //#in wrong class
        public Period Period
        {
            get { return period; }
        }

        public int Id { get; set; }

        //#should be Id, and title
        public Task(string title, DateTime dateTime)
        {
            Title = title;
            DateTime = dateTime; //#in wrong class
        }

        /// <summary>
        /// Get single task that is displayed in list of tasks for adding
        /// </summary>
        /// <returns>id and title</returns>
        public override string ToString()
        {
            return Id + " - " + Title;
        }

        /// <summary>
        /// For ordering by date added tasks
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        //#This should not be here! List of tasks to choose from, and list of added dones.
        // I don't know what to call the different things
        public int CompareTo(Task other)
        {
            return DateTime.CompareTo(other.DateTime);
        }
    }
}
