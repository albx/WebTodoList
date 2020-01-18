using System;
using System.Linq;
using System.Threading.Tasks;
using WebTodoList.Core.Models;

namespace WebTodoList.Core.Services
{
    public interface ITodoServices
    {
        IQueryable<TodoItem> Find();

        Task CreateNewTodoItem(string todoItemText);

        Task MarkTodoAsDone(Guid todoId);

        Task DeleteTodo(Guid todoId);
    }
}
