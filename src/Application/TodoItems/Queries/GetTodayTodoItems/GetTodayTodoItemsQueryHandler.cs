using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using MediatR;

namespace Application.TodoItems.Queries.GetTodayTodoItems
{
    internal sealed class GetTodayTodoItemsQueryHandler : IRequestHandler<GetTodayTodoItemsQuery, TodoItemViewModel[]>
    {
        private readonly ITodoContext _todoContext;

        public GetTodayTodoItemsQueryHandler(ITodoContext todoContext) => _todoContext = todoContext;

        public async Task<TodoItemViewModel[]> Handle(GetTodayTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return await _todoContext.TodoItems
                .Where(t => t.DueDate != null && t.DueDate.Value.Date == DateTime.UtcNow.Date)
                .Select(t => new TodoItemViewModel(t.Title, t.IsDone, t.DoneDate, t.DueDate))
                .ToArrayAsync(cancellationToken);
        }
    }
}
