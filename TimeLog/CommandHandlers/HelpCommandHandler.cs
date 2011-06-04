using System;
using System.IO;
using TimeLog.Commands;

namespace TimeLog.CommandHandlers
{
    public class HelpCommandHandler : CommandHandler<HelpCommand>
    {
        private readonly TextWriter textWriter;

        public HelpCommandHandler(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        protected override void DoHandleCommand(HelpCommand command)
        {
            textWriter.WriteLine(
                @"Usage:
                   q - quit
                   v - view tasks
                   h - this help
                   add - eg. add""1 2 3""");
        }
    }
}