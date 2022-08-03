using Application.Common;

namespace Application.TodoItems.Commands.SetDueDateTodoItem
{
    public class SetDueDateTodoItemCommand : ICommand
    {
        public SetDueDateTodoItemCommand(int id, DateTime dueDate)
        {
            Id = id;
            DueDate = dueDate;
        }

        public int Id { get; }
        public DateTime DueDate { get; }
    }
}
