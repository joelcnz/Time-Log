using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog
{
    /// <summary>
    /// Record the length of time some thing is done in
    /// </summary>
    public class Period
    {
        private int hours;
        private int minutes;
        private int seconds;

        public Period(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        public override string ToString()
        {
            return hours + ":" + minutes + ":" + seconds;
        }

    }
}
