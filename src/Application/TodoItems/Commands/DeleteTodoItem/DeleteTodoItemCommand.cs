using Application.Common;

namespace Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : ICommand
    {
        public DeleteTodoItemCommand(int id) => Id = id;

        public int Id { get; }
    }
}