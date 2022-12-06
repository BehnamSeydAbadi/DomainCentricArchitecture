using MediatR;

namespace Application.TodoItems.Queries.GetTodayTodoItems
{
    public class GetTodayTodoItemsQuery : IRequest<TodoItemViewModel[]>
    {
        public static GetTodayTodoItemsQuery Default => new();
    }
}
