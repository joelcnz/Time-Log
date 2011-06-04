using System;
using TimeLog.Commands;

namespace TimeLog
{
    class UserControl
    {
        private readonly CommandlineParser commandlineParser;
        private readonly CommandProcessor commandProcessor;

        public UserControl(CommandProcessor commandProcessor, CommandlineParser commandlineParser)
        {
            this.commandProcessor = commandProcessor;
            this.commandlineParser = commandlineParser;
        }

        public void ControlPrompt() // need a better method name
        {
            Console.WriteLine("Enter 'q' to quit, 'h' for help:");
            var input = Console.ReadLine();

            try
            {
                var command = commandlineParser.ParseCommandline(input);

                commandProcessor.ProcessCommand(command);
            }
            catch (InvalidCommandlineException exception)
            {
                // if we get an error from wrong command syntax, just display help
                Console.WriteLine(exception.Message);
                commandProcessor.ProcessCommand(new HelpCommand());
            }
        }
    } // class
} // namespace
