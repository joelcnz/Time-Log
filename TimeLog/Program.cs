//#not much right here
//#I would put a inner function here, but don't know how
#define SHORT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeLog.CommandHandlers;
using TimeLog.Model;

namespace TimeLog
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandProcessor = new CommandProcessor();
            
            var taskRepository = new InMemoryTaskRepository();

            commandProcessor.RegisterCommandHandler(new HelpCommandHandler(Console.Out));
            commandProcessor.RegisterCommandHandler(new QuitCommandHandler());
            commandProcessor.RegisterCommandHandler(new ViewCommandHandler(taskRepository, Console.Out));
            commandProcessor.RegisterCommandHandler(new AddCommandHandler(taskRepository));
  
            var timeLog = new TimeLog(commandProcessor);
            timeLog.Run();
        }
    }
} // namespace
