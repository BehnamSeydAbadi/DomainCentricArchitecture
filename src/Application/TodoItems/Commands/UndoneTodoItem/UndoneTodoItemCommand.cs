using Application.Common;

namespace Application.TodoItems.Commands.UndoneTodoItem
{
    public sealed class UndoneTodoItemCommand : ICommand
    {
        public UndoneTodoItemCommand(int id) => Id = id;

        public int Id { get; }
    }
}