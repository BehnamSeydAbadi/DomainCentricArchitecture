using Application.Common;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoItems.Queries.GetTodayTodoItems
{
    internal sealed class GetTodayTodoItemsQueryHandler : IQueryHandler<TodoItemViewModel>
    {
        private readonly ITodoContext _todoContext;

        public GetTodayTodoItemsQueryHandler(ITodoContext todoContext) => _todoContext = todoContext;

        public async Task<TodoItemViewModel[]> HandleAsync()
        {
            return await _todoContext.TodoItems
                .Where(t => t.DueDate != null && t.DueDate == DateTime.Today.Date)
                .Select(t => new TodoItemViewModel(t.Title, t.IsDone, t.DoneDate, t.DueDate))
                .ToArrayAsync();
        }
    }
}
