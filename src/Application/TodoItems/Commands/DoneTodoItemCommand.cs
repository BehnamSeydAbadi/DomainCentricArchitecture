using Application.Common;

namespace Application.TodoItems.Commands
{
    public sealed class DoneTodoItemCommand : ICommand
    {
        public DoneTodoItemCommand(int id) => Id = id;

        public int Id { get; }
    }
}