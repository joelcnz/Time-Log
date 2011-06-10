using System.Collections.Generic;

namespace TimeLog.Model
{
    /// <summary>
    /// Wrapper for storage of the task list.
    /// </summary>
    /// <remarks>
    /// Need to be able to save this to persistent storage like on the file system or something when.
    /// </remarks>
    public interface ITaskRepository
    {
        IEnumerable<DoingTask> GetAll();

        void Add(DoingTask task);
    }
}