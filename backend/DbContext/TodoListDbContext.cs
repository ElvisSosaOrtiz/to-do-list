namespace DbContext
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext() {   }

        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options) {    }

        public virtual DbSet<TaskEntity> Tasks { get; set; }
    }
}
