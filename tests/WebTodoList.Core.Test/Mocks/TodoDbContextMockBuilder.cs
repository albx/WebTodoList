using Microsoft.EntityFrameworkCore;
using System;
using WebTodoList.Core.Models;
using WebTodoList.Core.Persistence;

namespace WebTodoList.Core.Test.Mocks
{
    public class TodoDbContextMockBuilder : IDisposable
    {
        public DbContextOptions<TodoDbContext> Options { get; private set; }

        public TodoDbContextMockBuilder()
        {
            BuildDbContextOptions();
        }

        public TodoDbContext BuildDbContext()
        {
            var context = new TodoDbContext(this.Options);
            return context;
        }

        public void PrepareData(TodoDbContext context, TodoItem[] items)
        {
            context.TodoItems.AddRange(items);
            context.SaveChanges();
        }

        public void CleanAllData(TodoDbContext context)
        {
            context.TodoItems.RemoveRange(context.TodoItems);
            context.SaveChanges();
        }

        public void Dispose() { }

        private void BuildDbContextOptions()
        {
            var options = new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase("Todo_InMemory")
                .Options;

            this.Options = options;
        }
    }
}
