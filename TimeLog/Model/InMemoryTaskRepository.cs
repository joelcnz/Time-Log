using System.Collections.Generic;

namespace TimeLog.Model
{
    /// <summary>
    /// Wrapper for storage of the task list.
    /// </summary>
    /// <remarks>
    /// Need to be able to save this to persistent storage like on the file system or something when.
    /// </remarks>
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly IList<Task> taskList;

        public InMemoryTaskRepository()
        {
            taskList = new List<Task>();
        }

        public IEnumerable<Task> GetAll()
        {
            return taskList;
        }

        public void Add(Task task)
        {
            taskList.Add(task);
        }
    }
}