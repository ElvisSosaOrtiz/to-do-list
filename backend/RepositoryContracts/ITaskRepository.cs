namespace RepositoryContracts
{
    using Entities;
    using Shared.TaskController.Request;
    using System.Linq;

    public interface ITaskRepository
    {
        TaskEntity CreateTask(RequestOfManageTask request);
        string RemoveTask(int taskId);
        IQueryable<TaskEntity> GetAllTasks();
        TaskEntity? GetTaskDetails(int taskId);
        TaskEntity? UpdateTask(RequestOfManageTask request);
    }
}
