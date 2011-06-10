
using System;

namespace TimeLog.Model
{
    public class DoingTask: IComparable<DoingTask>
    {
        public DoingTask(Task task, DateTime dateTime)
        {
            if (task == null) throw new ArgumentNullException("task");
            Task = task;
            DateTime = dateTime;
        }

        public Task Task { get; private set; }

        public DateTime DateTime { get; private set; }

        public Period Period { get; private set; }

        public int CompareTo(DoingTask other)
        {
            return DateTime.CompareTo(other.DateTime);
        }
    }
}
