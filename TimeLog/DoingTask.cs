//#return what? I do not know.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog.Model
{
    class DoingTask: IComparable<Task>
    {
        public DoingTask(int id, DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public IEnumerable<DoingTask> GetAll()
        {
            //return; //#return what? I do not know.
        }

        public DateTime DateTime { get; private set; }

        public Period Period
        {
            get { return period; }
        }
        private Period period;

        public string Title
        {
            get { return title; }
        }
        private string title;

        public int CompareTo(DoingTask other)
        {
            return DateTime.CompareTo(other.DateTime);
        }
    }
}
