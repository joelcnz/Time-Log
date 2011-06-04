using System;
using TimeLog.Commands;
using TimeLog.Infrastructure;
using TimeLog.Model;

namespace TimeLog.CommandHandlers
{
    public class AddCommandHandler : CommandHandler<AddCommand>
    {
        private readonly ITaskRepository taskRepository;

        public AddCommandHandler(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        protected override void DoHandleCommand(AddCommand command)
        {
            taskRepository.Add(new Task(command.TaskTitle, DateTime.Now));
        }
    }
}