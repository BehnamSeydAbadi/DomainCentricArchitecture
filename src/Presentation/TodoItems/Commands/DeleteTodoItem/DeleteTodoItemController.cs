using Application.Common;
using Application.TodoItems.Commands.DeleteTodoItem;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemController : BaseApiController
    {
        private readonly ICommandHandler<DeleteTodoItemCommand> _commandHandler;

        public DeleteTodoItemController(ICommandHandler<DeleteTodoItemCommand> commandHandler)
            => _commandHandler = commandHandler;

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _commandHandler.HandleAsync(new DeleteTodoItemCommand(id));

            return Ok();
        }
    }
}
