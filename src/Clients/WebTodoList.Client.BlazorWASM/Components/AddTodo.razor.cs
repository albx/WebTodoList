using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebTodoList.ViewModels.Todo;

namespace WebTodoList.Client.BlazorWASM.Components
{
    public partial class AddTodo
    {
        private string newTodoText;

        [Inject]
        public HttpClient HttpClient { get; set; }

        [Parameter]
        public EventCallback<string> OnNewTodoItemAdded { get; set; }

        async Task AddNewTodo()
        {
            var newTodoViewModel = new NewTodoViewModel(newTodoText);

            await HttpClient.PostAsJsonAsync("api/todo", newTodoViewModel);
            await OnNewTodoItemAdded.InvokeAsync(newTodoText);

            newTodoText = string.Empty;
        }
    }
}
