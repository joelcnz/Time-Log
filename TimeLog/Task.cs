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
        private int id;
        private string comment;
        private Period timePeriod;
        private DateTime dateTime; // for date and time in one number I think. 
        //private Date date; // year, month and day of the month

        public Task(DateTime dateTime)
        {
            this.dateTime = dateTime; //#not sure about this
        }

        public DateTime GetDateTime()
        {
            return dateTime;
        }

        public int CompareTo(Task other)
        {
            return GetDateTime().CompareTo(other.GetDateTime());
        }

        public override string ToString()
        {
            return dateTime.ToString();
        }

        /*
        public int Compare(Object t2)
        {
            //#I don't know the order
            if ( dateTime.Millisecond < ((Task)t2).GetDateTime().Millisecond )
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        */

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}
