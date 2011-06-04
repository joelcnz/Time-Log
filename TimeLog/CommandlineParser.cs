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
                return new HelpCommand();

            var commandLineSegments = commandline.Split(' ');
            var commandLineSegment = commandLineSegments[0];
            switch (commandLineSegment)
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
                    throw new InvalidCommandlineException("Unrecognised commandline: " + commandLineSegment);
            }
        }
    }
}
