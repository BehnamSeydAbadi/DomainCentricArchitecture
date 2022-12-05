using MediatR;

namespace Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest
    {
        public DeleteTodoItemCommand(int id) => Id = id;

        public int Id { get; }
    }
}