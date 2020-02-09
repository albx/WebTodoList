using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTodoList.Api.Services;
using WebTodoList.ViewModels.Todo;

namespace WebTodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public TodoControllerServices ControllerServices { get; }

        public TodoController(TodoControllerServices controllerServices)
        {
            ControllerServices = controllerServices ?? throw new ArgumentNullException(nameof(controllerServices));
        }

        [HttpGet]
        public IActionResult Get(bool hideIfDone = false)
        {
            var viewModel = ControllerServices.GetTodoListItems(hideIfDone);
            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewTodoViewModel model)
        {
            await ControllerServices.CreateNewTodoItem(model);
            return Ok();
        }

        [HttpPatch("{id}/done")]
        public async Task<IActionResult> PatchDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid id");
            }

            await ControllerServices.MarkTodoAsDone(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid id");
            }

            await ControllerServices.DeleteTodo(id);
            return Ok();
        }
    }
}