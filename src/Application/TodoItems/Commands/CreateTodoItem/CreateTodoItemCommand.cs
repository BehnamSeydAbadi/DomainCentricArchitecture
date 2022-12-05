using MediatR;

namespace Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<int>
    {
        public CreateTodoItemCommand(string title) => Title = title;

        public string Title { get; }
    }
}
