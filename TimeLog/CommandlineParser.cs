using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TimeLog.Commands;
using TimeLog.Infrastructure;

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
                    var match = Regex.Match(commandline, @"""(.*?)""");
                    if (! match.Success)
                        throw new InvalidCommandlineException("'add' command requires number parameter(s)");
                    var result = match.Groups[1].Value;
                    return new AddCommand(result);

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
