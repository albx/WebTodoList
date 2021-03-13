using System.ComponentModel.DataAnnotations;

namespace WebTodoList.ViewModels.Todo
{
    public record NewTodoViewModel([Required]string Text);
}
