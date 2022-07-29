using Application.Common;

namespace Application.TodoItems.Commands.DoneTodoItem
{
    public sealed class DoneTodoItemCommand : ICommand
    {
        public DoneTodoItemCommand(int id) => Id = id;

        public int Id { get; }
    }
}