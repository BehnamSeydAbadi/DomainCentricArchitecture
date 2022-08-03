using Application.Common;
using Application.TodoItems.Commands.DoneTodoItem;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.TodoItems.Commands.DoneTodoItem
{
    public class DoneTodoItemController : BaseApiController
    {
        private readonly ICommandHandler<DoneTodoItemCommand> _commandHandler;

        public DoneTodoItemController(ICommandHandler<DoneTodoItemCommand> commandHandler)
            => _commandHandler = commandHandler;

        [HttpPut]
        public async Task<IActionResult> Put(int id)
        {
            await _commandHandler.HandleAsync(new DoneTodoItemCommand(id));

            return Ok();
        }
    }
}
