using System;
using TimeLog.Commands;
using TimeLog.Infrastructure;
using TimeLog.Model;
using System.IO;

namespace TimeLog.CommandHandlers
{
    public class ViewCommandHandler : CommandHandler<ViewCommand>
    {
        private readonly ITaskRepository taskRepository;
        private readonly TextWriter textWriter;

        public ViewCommandHandler(ITaskRepository taskRepository, TextWriter textWriter)
        {
            this.taskRepository = taskRepository;
            this.textWriter = textWriter;
        }

        protected override void DoHandleCommand(ViewCommand command)
        {
            foreach (var task in taskRepository.GetAll())
            {
                textWriter.WriteLine("{0} - {1}", task.Number, task.Title);
            }
        }
    }
}