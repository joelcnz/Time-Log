using System;
using TimeLog.Commands;
using TimeLog.Infrastructure;

namespace TimeLog.CommandHandlers
{
    public class QuitCommandHandler : CommandHandler<QuitCommand>
    {
        protected override void DoHandleCommand(QuitCommand command)
        {
            Environment.Exit(0);
        }
    }
}