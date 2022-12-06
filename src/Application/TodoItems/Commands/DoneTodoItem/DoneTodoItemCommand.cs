using MediatR;

namespace Application.TodoItems.Commands.DoneTodoItem
{
    public sealed class DoneTodoItemCommand : IRequest
    {
        public DoneTodoItemCommand(int id) => Id = id;

        public int Id { get; }
    }
}