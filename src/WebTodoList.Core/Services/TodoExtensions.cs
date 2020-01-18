using System.Linq;
using WebTodoList.Core.Models;

namespace WebTodoList.Core.Services
{
    public static class TodoExtensions
    {
        public static IQueryable<TodoItem> NotDeleted(this IQueryable<TodoItem> items)
        {
            return from t in items
                   where !t.IsDeleted
                   select t;
        }
    }
}
