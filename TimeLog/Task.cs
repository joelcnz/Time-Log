//#I don't know the order
//#not sure about this
//#how do I sort a list of instances of Task?
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog
{
    //#how do I sort a list of instances of Task?
    public class Task : IComparable<Task>
    {
        private string comment;
        private Period timePeriod;
        private DateTime dateTime; // for date and time in one number I think. 
        //private Date date; // year, month and day of the month

        public int Id { get; set; }

        public Task(DateTime dateTime)
        {
            this.dateTime = dateTime; //#not sure about this
        }

        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
        }

        public override string ToString()
        {
            return dateTime.ToString();
        }

        public int CompareTo(Task other)
        {
            return DateTime.CompareTo(other.DateTime);
        }
    }
}
