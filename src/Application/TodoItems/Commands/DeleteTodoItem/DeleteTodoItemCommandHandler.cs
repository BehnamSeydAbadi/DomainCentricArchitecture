using Application.Common;
using Application.Interfaces;
using Application.TodoItems.Commands.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoItems.Commands.DeleteTodoItem
{
    public sealed class DeleteTodoItemCommandHandler : ICommandHandler<DeleteTodoItemCommand>
    {
        private readonly ITodoContext _todoContext;

        public DeleteTodoItemCommandHandler(ITodoContext todoContext) => _todoContext = todoContext;

        public async Task HandleAsync(DeleteTodoItemCommand command)
        {
            var todoItem = await _todoContext.TodoItems.SingleOrDefaultAsync(t => t.Id == command.Id);

            if (todoItem == null)
                throw new TodoItemNotFoundException();


            _todoContext.TodoItems.Remove(todoItem);

            await _todoContext.SaveChangesAsync();
        }
    }
}
