using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebTodoList.ViewModels.Todo;

namespace WebTodoList.Client.BlazorWASM.Components
{
    public partial class TodoList
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Parameter]
        public IEnumerable<ListItemViewModel> Items { get; set; }

        [Parameter]
        public EventCallback<ListItemViewModel> OnTodoItemMarkedAsDone { get; set; }

        [Parameter]
        public EventCallback<ListItemViewModel> OnTodoItemDeleted { get; set; }

        [Parameter]
        public EventCallback<bool> OnToggleCompletedItems { get; set; }

        private bool hideCompletedTask = false;

        async Task MarkTodoItemAsDone(ListItemViewModel item)
        {
            await HttpClient.PatchAsync($"api/todo/{item.Id}/done", null);
            await OnTodoItemMarkedAsDone.InvokeAsync(item);
        }

        async Task DeleteTodoItem(ListItemViewModel item)
        {
            await HttpClient.DeleteAsync($"api/todo/{item.Id}");
            await OnTodoItemDeleted.InvokeAsync(item);
        }

        async Task ToggleCompletedItems()
        {
            hideCompletedTask = !hideCompletedTask;
            await OnToggleCompletedItems.InvokeAsync(hideCompletedTask);
        }
    }
}
