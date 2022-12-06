using MediatR;

namespace Application.TodoItems.Commands.UndoneTodoItem
{
    public sealed class UndoneTodoItemCommand : IRequest
    {
        public UndoneTodoItemCommand(int id) => Id = id;

        public int Id { get; }
    }
}