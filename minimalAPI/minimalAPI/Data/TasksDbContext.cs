using Microsoft.EntityFrameworkCore;

namespace minimalAPI.Data
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options):base(options)
        {
            
        }
        public DbSet<Todo> Todos { get; set; }


    }
}
