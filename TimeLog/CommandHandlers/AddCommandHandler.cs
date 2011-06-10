using System;
using System.Linq;
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
            var lastTaskNumber = taskRepository.GetAll().Max(t => t.Number);
            var task = new Task(lastTaskNumber+1)
                           {
                               Title = command.TaskTitle
                           };
            taskRepository.Add(task);
        }
    }
}