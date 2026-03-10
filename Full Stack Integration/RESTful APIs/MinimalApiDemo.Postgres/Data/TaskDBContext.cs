using Microsoft.EntityFrameworkCore;
using MinimalApiDemo.Postgres.Models;

namespace MinimalApiDemo.Postgres.Data
{
    public class TaskDbContext : DbContext
    {
        
        public TaskDbContext (DbContextOptions<TaskDbContext> options)
                :base(options)
                {
                }
        public DbSet<TaskItem> Tasks {get; set; } = null!;
    }
}