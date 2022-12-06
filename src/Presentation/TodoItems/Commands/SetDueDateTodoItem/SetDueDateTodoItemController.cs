using Application.TodoItems.Commands.SetDueDateTodoItem;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;
using MediatR;

namespace Presentation.TodoItems.Commands.SetDueDateTodoItem
{
    public class SetDueDateTodoItemController : BaseApiController
    {
        private readonly ISender _mediator;

        public SetDueDateTodoItemController(ISender mediator) => _mediator = mediator;

        [HttpPut]
        public async Task<IActionResult> Put(DueDateDto dto)
        {
            await _mediator.Send(new SetDueDateTodoItemCommand(dto.Id, dto.DueDate));

            return Ok();
        }
    }
}
