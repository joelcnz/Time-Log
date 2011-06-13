//#as?
using System;

namespace TimeLog.Infrastructure
{
    public abstract class CommandHandler<TCommand> : ICommandHandler where TCommand : class, ICommand
    {
        public bool CanHandleCommandsOfType(Type type)
        {
            return typeof(TCommand) == type;
        }

        public void HandleCommand(ICommand command)
        {
            if (command == null) throw new ArgumentNullException("command");

            if (command.GetType() != typeof(TCommand)) throw new ArgumentException("Command type not supported");

            DoHandleCommand(command as TCommand); //#as?
        }

        protected abstract void DoHandleCommand(TCommand command);
    }
}