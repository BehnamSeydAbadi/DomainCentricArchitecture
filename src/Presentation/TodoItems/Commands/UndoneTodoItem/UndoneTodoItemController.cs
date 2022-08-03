using Application.Common;
using Application.TodoItems.Commands.UndoneTodoItem;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.TodoItems.Commands.UndoneTodoItem
{
    public class UndoneTodoItemController : BaseApiController
    {
        private readonly ICommandHandler<UndoneTodoItemCommand> _commandHandler;

        public UndoneTodoItemController(ICommandHandler<UndoneTodoItemCommand> commandHandler)
            => _commandHandler = commandHandler;

        [HttpPut]
        public async Task<IActionResult> Put(int id)
        {
            await _commandHandler.HandleAsync(new UndoneTodoItemCommand(id));

            return Ok();
        }
    }
}
