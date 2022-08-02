using Application.Common;
using Application.TodoItems.Queries.GetTodayTodoItems;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.TodoItems.Queries
{
    public class TodayController : BaseApiController
    {
        private readonly IQueryHandler<TodoItemViewModel> _queryHandler;

        public TodayController(IQueryHandler<TodoItemViewModel> queryHandler) => _queryHandler = queryHandler;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todayTodoItems = await _queryHandler.HandleAsync();

            return Ok(todayTodoItems);
        }
    }
}
