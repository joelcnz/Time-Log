using TimeLog.Infrastructure;

namespace TimeLog.Commands
{
    public class AddCommand : ICommand
    {
        public AddCommand(string taskTitle)
        {
            TaskTitle = taskTitle;
        }

        public string TaskTitle { get; private set; }
    }
}