using Application.TodoItems.Commands.DoneTodoItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.TodoItems.Commands.DoneTodoItem
{
    public class DoneTodoItemController : BaseApiController
    {
        private readonly ISender _mediator;

        public DoneTodoItemController(ISender mediator) => _mediator = mediator;

        [HttpPut]
        public async Task<IActionResult> Put(int id)
        {
            await _mediator.Send(new DoneTodoItemCommand(id));

            return Ok();
        }
    }
}
