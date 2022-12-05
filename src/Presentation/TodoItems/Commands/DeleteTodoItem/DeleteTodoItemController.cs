using Application.TodoItems.Commands.DeleteTodoItem;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;
using MediatR;

namespace Presentation.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemController : BaseApiController
    {
        private readonly ISender _mediator;

        public DeleteTodoItemController(ISender mediator) => _mediator = mediator;

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTodoItemCommand(id));

            return Ok();
        }
    }
}
