using Application.Common;
using Application.Interfaces;
using Domain.TodoItems;

namespace Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandHandler : ICommandHandler<CreateTodoItemCommand>
    {
        private readonly ITodoContext _todoContext;

        public CreateTodoItemCommandHandler(ITodoContext todoContext) => _todoContext = todoContext;

        public async Task HandleAsync(CreateTodoItemCommand command)
        {
            var todoItem = new TodoItem(command.Title);

            await _todoContext.TodoItems.AddAsync(todoItem);
            await _todoContext.SaveChangesAsync();

            command.TodoId = todoItem.Id;
        }
    }
}
