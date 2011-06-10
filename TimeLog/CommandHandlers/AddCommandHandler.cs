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
            int nextTaskNumber = GetTaskNumber();
            var task = new Task(nextTaskNumber)
                           {
                               Title = command.TaskTitle
                           };
            taskRepository.Add(task);
        }

        private int GetTaskNumber()
        {
            var existingTasks = taskRepository.GetAll();
            if (! existingTasks.Any())
            {
                return 1;
            }
            else
            {
                var lastTaskNumber = taskRepository.GetAll().Max(t => t.Number);
                return lastTaskNumber + 1;
            }
        }
    }
}