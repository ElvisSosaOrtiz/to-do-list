namespace RepositoryContracts
{
    using Entities;
    using Shared.TaskController.Request;
    using System.Linq;

    public interface ITaskRepository
    {
        /// <summary>
        /// Adds a task to the database.
        /// </summary>
        /// <param name="request">The request body from which the task is created.</param>
        /// <returns>A reference of the task entity.</returns>
        TaskEntity CreateTask(RequestOfManageTask request);

        /// <summary>
        /// Removes a task from the database.
        /// </summary>
        /// <param name="taskId">The id of the task to remove.</param>
        /// <returns>A message confirmation of the task removal.</returns>
        string RemoveTask(int taskId);

        /// <summary>
        /// Retrieves all tasks from the database.
        /// </summary>
        /// <returns>A collection of tasks.</returns>
        IQueryable<TaskEntity> GetAllTasks();

        /// <summary>
        /// Gets a task by it's id.
        /// </summary>
        /// <param name="taskId">The id of the task to retrieve.</param>
        /// <returns>A reference of the task entity.</returns>
        TaskEntity? GetTaskDetails(int taskId);

        /// <summary>
        /// Modifies the task selected by the id from the request body.
        /// </summary>
        /// <param name="request">The request body from which the task is edited.</param>
        /// <returns>A reference of the task entity.</returns>
        TaskEntity? UpdateTask(RequestOfManageTask request);
    }
}
