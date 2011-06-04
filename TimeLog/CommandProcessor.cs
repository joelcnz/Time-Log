using System;
using System.Collections.Generic;
using TimeLog.CommandHandlers;
using TimeLog.Commands;

namespace TimeLog
{
    /// <summary>
    /// Central registry for command handlers.
    /// Designed to direct <see cref="ICommand"/>s to the appropriate <see cref="ICommandHandler"/> that has been registered.
    /// </summary>
    public class CommandProcessor
    {
        private readonly IList<ICommandHandler> registeredHandlers;

        public CommandProcessor()
        {
            registeredHandlers = new List<ICommandHandler>();
        }

        /// <summary>
        /// Registers a handler to be used to process commands.
        /// </summary>
        public void RegisterCommandHandler(ICommandHandler commandHandler)
        {
            registeredHandlers.Add(commandHandler);
        }

        /// <summary>
        /// Processes the command by asking all registered handlers if they handle that type of command
        /// and if they do asking them to handle it. 
        /// 
        /// If no handlers are registered for that type of command, an exception is thrown.
        /// </summary>
        public void ProcessCommand(ICommand command)
        {
            if (command == null) throw new ArgumentNullException("command");

            bool handlerFound = false;

            foreach (var handler in registeredHandlers)
            {
                if (handler.CanHandleCommandsOfType(command.GetType()))
                {
                    handlerFound = true;
                    handler.HandleCommand(command);
                }
            }

            if (! handlerFound)
            {
                throw new InvalidOperationException("No command handler registered for command of type: " + command.GetType());
            }
        }
    }
}