using Common.Exception;

namespace Application.TodoItems.Commands.Common
{
    public class TodoItemNotFoundException : Exception, IException
    {
        public TodoItemNotFoundException() : base("TodoItem not found.") { }
    }
}