using Application.Common;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoItems.Commands
{
    public class DoneTodoItemCommandHandler : ICommandHandler<DoneTodoItemCommand>
    {
        private readonly ITodoContext _todoContext;

        public DoneTodoItemCommandHandler(ITodoContext todoContext) => _todoContext = todoContext;

        public async Task HandleAsync(DoneTodoItemCommand command)
        {
            var todoItem = await _todoContext.TodoItems
                .SingleOrDefaultAsync(t => t.Id == command.Id);

            if (todoItem == null)
                throw new TodoItemNotFoundException();


            todoItem.MakeItDone();

            _todoContext.TodoItems.Update(todoItem);

            await _todoContext.SaveChangesAsync();
        }
    }
}
