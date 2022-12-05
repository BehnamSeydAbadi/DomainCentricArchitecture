using Application.Interfaces;
using Domain.TodoItems;
using MediatR;

namespace Application.TodoItems.Commands.CreateTodoItem
{
    internal sealed class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
    {
        private readonly ITodoContext _todoContext;

        public CreateTodoItemCommandHandler(ITodoContext todoContext) => _todoContext = todoContext;

        public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem(request.Title);

            await _todoContext.TodoItems.AddAsync(todoItem);
            await _todoContext.SaveChangesAsync();

            return todoItem.Id;
        }
    }
}
