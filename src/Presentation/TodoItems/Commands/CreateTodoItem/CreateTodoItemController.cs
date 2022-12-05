using Application.TodoItems.Commands.CreateTodoItem;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;
using MediatR;

namespace Presentation.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemController : BaseApiController
    {
        private readonly ISender _mediator;

        public CreateTodoItemController(ISender mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Post(CreateTodoItemDto dto)
        {
            var command = new CreateTodoItemCommand(dto.Title);

            var id = await _mediator.Send(command);

            return Ok(id);
        }
    }
}
