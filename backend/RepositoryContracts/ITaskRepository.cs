namespace RepositoryContracts
{
    using Entities;
    using System.Linq;

    public interface ITaskRepository
    {
        void CreateTask(TaskEntity taskEntity);
        void RemoveTask(TaskEntity taskEntity);
        IQueryable<TaskEntity> GetAllTasks();
        TaskEntity? GetTaskDetails(int taskId);
        void UpdateTask(TaskEntity taskEntity);
    }
}
