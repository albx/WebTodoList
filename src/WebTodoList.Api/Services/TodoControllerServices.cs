using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTodoList.Core.Services;
using WebTodoList.ViewModels.Todo;

namespace WebTodoList.Api.Services
{
    public class TodoControllerServices
    {
        private readonly ITodoServices _todoServices;

        public TodoControllerServices(ITodoServices todoServices)
        {
            _todoServices = todoServices ?? throw new ArgumentNullException(nameof(todoServices));
        }

        public IEnumerable<ListItemViewModel> GetTodoListItems()
        {
            var todos = _todoServices.Find()
                .NotDeleted()
                .Select(t => new ListItemViewModel
                {
                    Id = t.Id,
                    IsDone = t.IsDone,
                    Text = t.Text
                }).ToArray();

            return todos;
        }

        public async Task CreateNewTodoItem(NewTodoViewModel model)
        {
            await _todoServices.CreateNewTodoItem(model.Text);
        }

        public async Task MarkTodoAsDone(Guid todoId)
        {
            await _todoServices.MarkTodoAsDone(todoId);
        }

        public async Task DeleteTodo(Guid todoId)
        {
            await _todoServices.DeleteTodo(todoId);
        }
    }
}
