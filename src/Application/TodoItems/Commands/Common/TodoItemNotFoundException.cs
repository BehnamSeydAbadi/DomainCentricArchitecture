namespace Application.TodoItems.Commands.Common
{
    public class TodoItemNotFoundException : Exception
    {
        public TodoItemNotFoundException() : base("TodoItem not found.") { }
    }
}