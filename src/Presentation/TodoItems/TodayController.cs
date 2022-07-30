using Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.TodoItems
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodayController : ControllerBase
    {
        private readonly IQueryHandler<TodoItem> _queryHandler;

        public TodayController(IQueryHandler<TodoItem> queryHandler) => _queryHandler = queryHandler;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
        }
    }
}
