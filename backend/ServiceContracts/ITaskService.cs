namespace ServiceContracts
{
    using Shared.TaskController.Request;
    using Shared.TaskController.Response;

    public interface ITaskService
    {
        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="request">The request body from which the task is created.</param>
        /// <returns>A response body of the created task.</returns>
        ResponseOfGetTasks.SingleTask AddNewTask(RequestOfManageTask request);
        
        /// <summary>
        /// Removes a selected task.
        /// </summary>
        /// <param name="taskId">The id of the task selected to remove.</param>
        /// <returns>A message confirmation of the task removal.</returns>
        string DeleteTask(int taskId);

        /// <summary>
        /// Modifies the task selected by the id from the request body.
        /// </summary>
        /// <param name="request">The request body from which the task is edited.</param>
        /// <returns>A response body of the edited task.</returns>
        ResponseOfGetTasks.SingleTask? EditTask(RequestOfManageTask request);

        /// <summary>
        /// Gets the task by the provided id.
        /// </summary>
        /// <param name="taskId">The id of the task selected to retrieve.</param>
        /// <returns>A response body of the retrieved task.</returns>
        ResponseOfGetTasks.SingleTask? GetTaskById(int taskId);

        /// <summary>
        /// Gets all the tasks.
        /// </summary>
        /// <returns>A response body containing the collection of tasks.</returns>
        ResponseOfGetTasks ListAllTasks();
    }
}
