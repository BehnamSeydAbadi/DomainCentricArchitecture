using Application.TodoItems.Commands.UndoneTodoItem;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;
using MediatR;

namespace Presentation.TodoItems.Commands.UndoneTodoItem
{
    public class UndoneTodoItemController : BaseApiController
    {
        private readonly ISender _mediator;

        public UndoneTodoItemController(ISender mediator) => _mediator = mediator;

        [HttpPut]
        public async Task<IActionResult> Put(int id)
        {
            await _mediator.Send(new UndoneTodoItemCommand(id));

            return Ok();
        }
    }
}
