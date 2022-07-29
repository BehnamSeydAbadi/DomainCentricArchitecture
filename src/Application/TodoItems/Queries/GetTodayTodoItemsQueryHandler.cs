using Application.Common;
using Application.Interfaces;
using Domain.TodoItems;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoItems.Queries
{
    public class GetTodayTodoItemsQueryHandler : IQueryHandler<TodoItem>
    {
        private readonly ITodoContext _todoContext;

        public GetTodayTodoItemsQueryHandler(ITodoContext todoContext) => _todoContext = todoContext;

        public async Task<TodoItem[]> HandleAsync()
        {
            return await _todoContext.TodoItems
                .Where(t => t.DueDate != null && t.DueDate == DateTime.Today.Date)
                .ToArrayAsync();
        }
    }
}
