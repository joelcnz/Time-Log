using System;
using TimeLog.Commands;

namespace TimeLog.CommandHandlers
{
    public abstract class CommandHandler<TCommand> : ICommandHandler where TCommand : ICommand
    {
        public bool CanHandleCommand(Type type)
        {
            return typeof(TCommand) == type;
        }

        public abstract void HandleCommand(ICommand command);
    }
}