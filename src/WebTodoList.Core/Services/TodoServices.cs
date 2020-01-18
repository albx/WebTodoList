using System;
using System.Linq;
using System.Threading.Tasks;
using WebTodoList.Core.Models;
using WebTodoList.Core.Persistence;

namespace WebTodoList.Core.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly TodoDbContext _context;

        public TodoServices(TodoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<TodoItem> Find() => _context.TodoItems;

        public async Task CreateNewTodoItem(string todoItemText)
        {
            var newTodo = TodoItem.NewTodo(todoItemText);
            _context.Add(newTodo);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodo(Guid todoId)
        {
            var todo = _context.TodoItems.Find(todoId);
            todo.Delete();

            await _context.SaveChangesAsync();
        }

        public async Task MarkTodoAsDone(Guid todoId)
        {
            var todo = _context.TodoItems.Find(todoId);
            todo.MarkAsDone();

            await _context.SaveChangesAsync();
        }
    }
}
