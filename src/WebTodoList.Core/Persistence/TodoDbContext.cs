using Microsoft.EntityFrameworkCore;
using WebTodoList.Core.Models;

namespace WebTodoList.Core.Persistence
{
    public class TodoDbContext : DbContext
    {
        public virtual DbSet<TodoItem> TodoItems { get; set; }

        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TodoItem>()
                .HasKey(t => t.Id);
        }
    }
}
