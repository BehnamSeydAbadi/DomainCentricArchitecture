using Application.Common;
using Application.TodoItems.Commands.CreateTodoItem;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.TodoItems.Commands
{
    public class CreateTodoItemController : BaseApiController
    {
        private readonly ICommandHandler<CreateTodoItemCommand> _commandHandler;

        public CreateTodoItemController(ICommandHandler<CreateTodoItemCommand> commandHandler)
            => _commandHandler = commandHandler;

        [HttpPost]
        public async Task<IActionResult> Post(CreateTodoItemDto dto)
        {
            var command = new CreateTodoItemCommand(dto.Title);

            await _commandHandler.HandleAsync(command);

            return Ok(command.Id);
        }
    }
}
