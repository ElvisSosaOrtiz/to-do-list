namespace Services
{
    using Entities;
    using Microsoft.Extensions.Logging;
    using RepositoryContracts;
    using ServiceContracts;
    using Shared.TaskController.Request;
    using Shared.TaskController.Response;
    using System.Reflection;

    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly ILogger<TaskService> _logger;

        public TaskService(
            ITaskRepository repository,
            ILogger<TaskService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public ResponseOfGetTasks ListAllTasks()
        {
            try
            {
                return new()
                {
                    Task = _repository.GetAllTasks().Select(t => new ResponseOfGetTasks.SingleTask
                    {
                        TaskId = t.TaskId,
                        Title = t.Title,
                        Description = t.Description,
                        DueDate = t.DueDate,
                        IsCompleted = t.IsCompleted
                    })
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return ResponseOfGetTasks.Empty;
            }
        }

        public ResponseOfGetTasks.SingleTask GetTaskById(int taskId)
        {
            try
            {
                var task = _repository.GetTaskDetails(taskId);
                if (task is null || task == new TaskEntity())
                {
                    _logger.LogError("Could not find task with id {0}", taskId);
                    return new();
                }

                return new()
                {
                    TaskId = task.TaskId,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    IsCompleted = task.IsCompleted
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new();
            }
        }

        public void AddNewTask(RequestOfManageTask request)
        {
            try
            {
                if (IsAnyPropertyNullOrEmpty(request))
                {
                    _logger.LogError("One or more properties are empty");
                    throw new ApplicationException("One or more properties are empty");
                }

                var taskEntity = new TaskEntity
                {
                    TaskId = request.TaskId,
                    Title = request.Title,
                    Description = request.Description,
                    DueDate = request.DueDate,
                    IsCompleted = request.IsCompleted
                };

                _repository.CreateTask(taskEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public void EditTask(RequestOfManageTask request)
        {
            try
            {
                if (IsAnyPropertyNullOrEmpty(request))
                {
                    _logger.LogError("One or more properties are empty");
                    throw new ApplicationException("One or more properties are empty");
                }

                var taskEntity = new TaskEntity
                {
                    TaskId = request.TaskId,
                    Title = request.Title,
                    Description = request.Description,
                    DueDate = request.DueDate,
                    IsCompleted = request.IsCompleted
                };

                _repository.UpdateTask(taskEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public void DeleteTask(RequestOfManageTask request)
        {
            try
            {
                if (IsAnyPropertyNullOrEmpty(request))
                {
                    _logger.LogError("One or more properties are empty");
                    throw new ApplicationException("One or more properties are empty");
                }

                var taskEntity = new TaskEntity
                {
                    TaskId = request.TaskId,
                    Title = request.Title,
                    Description = request.Description,
                    DueDate = request.DueDate,
                    IsCompleted = request.IsCompleted
                };

                _repository.RemoveTask(taskEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        private static bool IsAnyPropertyNullOrEmpty(RequestOfManageTask request)
        {
            foreach (PropertyInfo pi in request.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string? value = (string?)pi.GetValue(request);
                    if (string.IsNullOrEmpty(value))
                    {
                        return false;
                    }
                }
            }

            return false;
        }
    }
}
