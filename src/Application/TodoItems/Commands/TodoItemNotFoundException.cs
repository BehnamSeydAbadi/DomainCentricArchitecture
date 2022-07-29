namespace Application.TodoItems.Commands
{
    public class TodoItemNotFoundException : Exception
    {
        public TodoItemNotFoundException() : base("TodoItem not found.") { }
    }
}