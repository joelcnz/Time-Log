//#not much right here
//#I would put a inner function here, but don't know how
#define SHORT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog
{
    class Program
    {
        static void Main(string[] args)
        {

            var taskList = new string[] { "Bible", "C#" };

            var userControl = new UserControl();

            new TimeLog( taskList, userControl);
        }
    }
} // namespace
