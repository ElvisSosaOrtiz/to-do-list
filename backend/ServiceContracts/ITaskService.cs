namespace ServiceContracts
{
    using Shared.TaskController.Request;
    using Shared.TaskController.Response;

    public interface ITaskService
    {
        ResponseOfGetTasks.SingleTask AddNewTask(RequestOfManageTask request);
        string DeleteTask(int taskId);
        ResponseOfGetTasks.SingleTask? EditTask(RequestOfManageTask request);
        ResponseOfGetTasks.SingleTask? GetTaskById(int taskId);
        ResponseOfGetTasks ListAllTasks();
    }
}
