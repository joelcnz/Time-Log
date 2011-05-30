using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog
{
    class TimeLog
    {
        public TimeLog( string[] taskList, UserControl userContol )
        {
            m_taskList = taskList;
            m_userControl = userContol;
            Run();
        }

        private void Run()
        {
            var input = "";
            var done = false;
            while (!done)
            {
                Console.WriteLine("Enter 'q' to quit, 'h' for help:");
                input = Console.ReadLine();
                var root = GetRoot(input);
                List<int> arguments = GetArguments(input);
                Console.WriteLine(
                        "root:" + root + "\n" +
                        "arguments: " + PrintArgs(arguments));
                done = m_userControl.SelectFromControl(root, arguments, m_taskList); //#not much that's right here
            }
        }

        private bool inBounds(int value, int min, int max)
        {
            return (value >= min && value <= max);
        }

        private List<int> GetArguments(string str)
        {
            var root = GetRoot( str );
            str = str.Substring( root.Length, str.Length - root.Length);
            bool isInBounds = true;
            if (inBounds(str.Length, 1, 42) == isInBounds)
            {
                const int quotes = 1;
                if (str[0] == '"')
                    str = str.Substring(quotes, str.Length - 1 - quotes);

                var numbers = new List<int>();
                foreach (var strNum in reduceGaps(str).Split(' '))
                {
                    Console.WriteLine( "'" + strNum + "'" );
                    numbers.Add(Convert.ToInt32(strNum));
                }
                return numbers;
            }

            return null;
        }

        private string reduceGaps(string str)
        {
            string oldStr = str;

            str = str.Replace("  ", " ");

            if (str == oldStr)
                return str.Trim();
            else
                return reduceGaps(str); // recursion call
        }

        private string PrintArgs(List<int> args)
        {
            if (args == null)
                return "";
            string argStr = "";

            foreach(var arg in args)
            {
                argStr += "<" + arg + "> ";
            }

            return argStr;
        }

        private bool IsNumber(char c)
        {
            if (c >= '0' && c <= '9')
                return true;

            return false;
        }

        private string GetRoot(string input)
        {
            var index = 0;
            for (int i = 0; i < input.Length; ++i)
                if (input[i] == '"' || IsNumber(input[i]) == true)
                    break;
                else
                    ++index;

            return input.Substring( 0, index );
        }

        private int[] GetNumbers(string input)
        {
            return new int[] { 1, 2, 3 };
        }

        private void Print(List<Task> tasks)
        {
            foreach (var task in tasks)
            {
                Console.WriteLine( task );
            }
        }

        private string[] m_taskList;
        private UserControl m_userControl;
    }
}
