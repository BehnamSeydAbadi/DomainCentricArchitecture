using Application.Common;
using Application.Interfaces;
using Application.TodoItems.Commands.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoItems.Commands.SetDueDateTodoItem
{
    internal class SetDueDateTodoItemCommandHandler : ICommandHandler<SetDueDateTodoItemCommand>
    {
        private readonly ITodoContext _todoContext;

        public SetDueDateTodoItemCommandHandler(ITodoContext todoContext) => _todoContext = todoContext;

        public async Task HandleAsync(SetDueDateTodoItemCommand command)
        {
            var todoItem = await _todoContext.TodoItems
                .SingleOrDefaultAsync(t => t.Id == command.Id);

            if (todoItem == null)
                throw new TodoItemNotFoundException();


            todoItem.SetDueDate(command.DueDate);

            _todoContext.TodoItems.Update(todoItem);

            await _todoContext.SaveChangesAsync();
        }
    }
}
