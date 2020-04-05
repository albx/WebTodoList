using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebTodoList.ViewModels.Todo;

namespace WebTodoList.Client.BlazorWASM.Pages
{
    public partial class Index
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        private IList<ListItemViewModel> todos;

        private bool hideIfDone = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadTodoItems();
        }

        async Task AddTodoItem(string newTodoText)
        {
            todos?.Add(new ListItemViewModel { Text = newTodoText });
            await LoadTodoItems(hideIfDone);
        }

        void MarkItemAsDone(ListItemViewModel item)
        {
            var todoItem = todos.SingleOrDefault(t => t.Id == item.Id);
            if (todoItem != null)
            {
                todoItem.IsDone = true;
                if (hideIfDone)
                {
                    todos.Remove(todoItem);
                }
            }
        }

        void RemoveItem(ListItemViewModel item)
        {
            var todoItem = todos.SingleOrDefault(t => t.Id == item.Id);
            if (todoItem != null)
            {
                todos.Remove(todoItem);
            }
        }

        async Task ToggleCompletedItems(bool hideCompletedItems)
        {
            hideIfDone = hideCompletedItems;
            await LoadTodoItems(hideIfDone);
        }

        async Task LoadTodoItems(bool hideCompletedItems = false)
        {
            todos = await HttpClient.GetJsonAsync<IList<ListItemViewModel>>($"api/todo?hideIfDone={hideCompletedItems}");
        }
    }
}
