//#I don't know the order
//#not sure about this
//#how do I sort a list of instances of Task?
using System;

namespace TimeLog.Model
{
    public class Task : IComparable<Task>
    {
        private Period period;

        public string Title { get; private set; }

        public DateTime DateTime { get; private set; }

        public Period Period
        {
            get { return period; }
        }

        public int Id { get; set; }

        public Task(string title, DateTime dateTime)
        {
            Title = title;
            this.DateTime = dateTime; //#not sure about this
        }

        public override string ToString()
        {
            return DateTime.ToString();
        }

        public int CompareTo(Task other)
        {
            return DateTime.CompareTo(other.DateTime);
        }
    }
}
