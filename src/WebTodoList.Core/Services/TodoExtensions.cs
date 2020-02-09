using System;
using System.Linq;
using WebTodoList.Core.Models;

namespace WebTodoList.Core.Services
{
    public static class TodoExtensions
    {
        public static IQueryable<TodoItem> NotDeleted(this IQueryable<TodoItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            return from t in items
                   where !t.IsDeleted
                   select t;
        }

        public static IQueryable<TodoItem> NotCompleted(this IQueryable<TodoItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            return from t in items
                   where !t.IsDone
                   select t;
        }
    }
}
