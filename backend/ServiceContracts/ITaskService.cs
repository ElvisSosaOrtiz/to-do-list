namespace ServiceContracts
{
    using Shared.TaskController.Request;
    using Shared.TaskController.Response;

    public interface ITaskService
    {
        void AddNewTask(RequestOfManageTask request);
        void DeleteTask(RequestOfManageTask request);
        void EditTask(RequestOfManageTask request);
        ResponseOfGetTasks.SingleTask GetTaskById(int taskId);
        ResponseOfGetTasks ListAllTasks();
    }
}
