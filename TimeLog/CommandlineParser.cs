using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeLog.Commands;

namespace TimeLog
{
    public class CommandlineParser
    {
     
        public ICommand ParseCommandline(string commandline)
        {
            if (string.IsNullOrEmpty(commandline))
                return null;

            var commandLineSegments = commandline.Split(' ');
            switch (commandLineSegments[0])
            {
                case "add":
                    return new AddCommand();

                case "h":
                    return new HelpCommand();
                
                case "v":
                    return new ViewCommand();

                case "q":
                    return new QuitCommand();

                default:
                    return null;
            }
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
