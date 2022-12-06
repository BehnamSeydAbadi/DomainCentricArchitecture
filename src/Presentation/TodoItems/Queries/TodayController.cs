using Application.TodoItems.Queries.GetTodayTodoItems;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;
using MediatR;

namespace Presentation.TodoItems.Queries
{
    public class TodayController : BaseApiController
    {
        private readonly ISender _mediator;

        public TodayController(ISender mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todayTodoItems = await _mediator.Send(GetTodayTodoItemsQuery.Default);

            return Ok(todayTodoItems);
        }
    }
}
