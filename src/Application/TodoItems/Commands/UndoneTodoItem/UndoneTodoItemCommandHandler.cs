using Application.Common;
using Application.Interfaces;
using Application.TodoItems.Commands.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoItems.Commands.UndoneTodoItem
{
    public class UndoneTodoItemCommandHandler : ICommandHandler<UndoneTodoItemCommand>
    {
        private readonly ITodoContext _todoContext;

        public UndoneTodoItemCommandHandler(ITodoContext todoContext) => _todoContext = todoContext;

        public async Task HandleAsync(UndoneTodoItemCommand command)
        {
            var todoItem = await _todoContext.TodoItems
                .SingleOrDefaultAsync(t => t.Id == command.Id);

            if (todoItem == null)
                throw new TodoItemNotFoundException();


            todoItem.MakeItUndone();

            _todoContext.TodoItems.Update(todoItem);

            await _todoContext.SaveChangesAsync();
        }
    }
}
