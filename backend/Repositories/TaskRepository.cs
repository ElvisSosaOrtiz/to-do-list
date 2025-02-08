namespace Repositories
{
    using DbContext;
    using Entities;
    using RepositoryContracts;

    public class TaskRepository : ITaskRepository
    {
        private readonly TodoListDbContext _dbContext;

        public TaskRepository(TodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TaskEntity> GetAllTasks() => _dbContext.Tasks;

        public TaskEntity? GetTaskDetails(int taskId) => _dbContext.Tasks.Find(taskId);

        public void CreateTask(TaskEntity taskEntity)
        {
            _dbContext.Tasks.Add(taskEntity);
            _dbContext.SaveChanges();
        }

        public void UpdateTask(TaskEntity taskEntity)
        {
            _dbContext.Tasks.Update(taskEntity);
            _dbContext.SaveChanges();
        }

        public void RemoveTask(TaskEntity taskEntity)
        {
            _dbContext.Tasks.Remove(taskEntity);
            _dbContext.SaveChanges();
        }
    }
}
