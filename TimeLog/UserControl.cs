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
            string input = "";

            Console.WriteLine("Enter 'q' to quit, 'h' for help:");
            input = Console.ReadLine();

            ICommand command;
            try
            {
                command = commandlineParser.ParseCommandline(input);
            }
            catch (Exception)
            {
                // if we get an error from wrong command syntax, just display help
                command = new HelpCommand();
            }

            commandProcessor.ProcessCommand(command);
        }
    } // class
} // namespace
