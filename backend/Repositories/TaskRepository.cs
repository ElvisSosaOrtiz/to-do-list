namespace Repositories
{
    using DbContext;
    using Entities;
    using RepositoryContracts;
    using Shared.TaskController.Request;

    public class TaskRepository : ITaskRepository
    {
        private readonly TodoListDbContext _dbContext;

        public TaskRepository(TodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TaskEntity> GetAllTasks() => _dbContext.Tasks;

        public TaskEntity? GetTaskDetails(int taskId) => _dbContext.Tasks.Find(taskId);

        public TaskEntity CreateTask(RequestOfManageTask request)
        {
            var taskEntity = new TaskEntity
            {
                TaskId = request.TaskId,
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                IsCompleted = request.IsCompleted
            };
            _dbContext.Tasks.Add(taskEntity);
            _dbContext.SaveChanges();

            return taskEntity;
        }

        public TaskEntity? UpdateTask(RequestOfManageTask request)
        {
            var taskEntity = _dbContext.Tasks.Find(request.TaskId);

            if (taskEntity is not null)
            {
                taskEntity.Title = request.Title;
                taskEntity.Description = request.Description;
                taskEntity.DueDate = request.DueDate;
                taskEntity.IsCompleted = request.IsCompleted;

                _dbContext.Tasks.Update(taskEntity);
                _dbContext.SaveChanges();
            }

            return taskEntity;
        }

        public string RemoveTask(int taskId)
        {
            var taskEntity = _dbContext.Tasks.Find(taskId);

            if (taskEntity is not null)
            {
                _dbContext.Tasks.Remove(taskEntity);
                _dbContext.SaveChanges();

                return string.Empty;
            }

            return "Could not find task to remove.";
        }
    }
}
