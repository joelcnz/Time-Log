using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog
{
    class UserControl
    {
        public bool SelectFromControl(string root, List<int> arguments, string[] taskList) // need a better method name
        {
            switch (root)
            { 
                case "q":
                    return true;
                case "h":
                    Console.WriteLine("Usage:\nq - quit\nv - view tasks\nh - this help\nadd - eg. add" + '"' + "1 2 3" + '"');
                    break;
                case "v":
                    int id = 0;
                    foreach( var task in taskList)
                    {
                        Console.WriteLine(id + ". " + task);
                        ++id;
                    }
                    break;
                case "add":
                    Console.Write("add: ");
                    int total = 0;
                    foreach (var number in arguments)
                    {
                        Console.Write(number + " ");
                        total += number;
                    }
                    Console.WriteLine(" - " + total);
                    break;
            }

            return false;
        }
    }
}
