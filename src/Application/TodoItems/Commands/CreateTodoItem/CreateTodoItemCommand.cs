using Application.Common;

namespace Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : ICommand
    {
        public CreateTodoItemCommand(string title) => Title = title;

        public string Title { get; }
        public int TodoId { get; internal set; }
    }
}
