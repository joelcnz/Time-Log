using System;
using TimeLog.Commands;

namespace TimeLog.CommandHandlers
{
    /// <summary>
    /// Interface for command handlers to implement.
    /// </summary>
    public interface ICommandHandler
    {
        /// <summary>
        /// Whether or not a command type implements a command.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool CanHandleCommandsOfType(Type type);

        /// <summary>
        /// Handle the command (i.e. do what the command asks).
        /// </summary>
        /// <param name="command"></param>
        void HandleCommand(ICommand command);
    }
}