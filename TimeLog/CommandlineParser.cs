using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeLog
{
    public class Command
    {
        public string Root { get; private set; }

        public Command(string root)
        {
            Root = root;
        }
    }

    public class CommandlineParser
    {
     
        public Command ParseCommandline(string commandline)
        {
            if (string.IsNullOrEmpty(commandline))
                return null;

            return new Command("add");
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

            return input.Substring(0, index);
        }
    }
}
