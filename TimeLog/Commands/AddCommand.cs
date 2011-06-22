//#not supposed to be title
using TimeLog.Infrastructure;

namespace TimeLog.Commands
{
    public class AddCommand : ICommand
    {
        public AddCommand(string taskTitle) //#not supposed to be title
        {
            TaskTitle = taskTitle;
        }

        public string TaskTitle { get; private set; }
    }
}