using MediatR;

namespace Application.TodoItems.Commands.SetDueDateTodoItem
{
    public class SetDueDateTodoItemCommand : IRequest
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
