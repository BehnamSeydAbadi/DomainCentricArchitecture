using Application.Common;
using Application.TodoItems.Queries.GetTodayTodoItems;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.TodoItems
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodayController : ControllerBase
    {
        private readonly IQueryHandler<TodoItemViewModel> _queryHandler;

        public TodayController(IQueryHandler<TodoItemViewModel> queryHandler) => _queryHandler = queryHandler;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
