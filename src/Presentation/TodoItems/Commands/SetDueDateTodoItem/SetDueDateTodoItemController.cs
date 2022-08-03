using Application.Common;
using Application.TodoItems.Commands.SetDueDateTodoItem;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.TodoItems.Commands.SetDueDateTodoItem
{
    public class SetDueDateTodoItemController : BaseApiController
    {
        private readonly ICommandHandler<SetDueDateTodoItemCommand> _commandHandler;

        public SetDueDateTodoItemController(ICommandHandler<SetDueDateTodoItemCommand> commandHandler)
            => _commandHandler = commandHandler;

        [HttpPut]
        public async Task<IActionResult> Put(DueDateDto dto)
        {
            await _commandHandler.HandleAsync(new SetDueDateTodoItemCommand(dto.Id, dto.DueDate));

            return Ok();
        }
    }
}
