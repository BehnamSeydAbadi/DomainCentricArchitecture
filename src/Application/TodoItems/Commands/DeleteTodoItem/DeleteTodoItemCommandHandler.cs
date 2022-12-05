using Application.Interfaces;
using Application.TodoItems.Commands.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoItems.Commands.DeleteTodoItem
{
    internal sealed class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly ITodoContext _todoContext;

        public DeleteTodoItemCommandHandler(ITodoContext todoContext) => _todoContext = todoContext;

        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _todoContext.TodoItems.SingleOrDefaultAsync(t => t.Id == request.Id);

            if (todoItem == null)
                throw new TodoItemNotFoundException();


            _todoContext.TodoItems.Remove(todoItem);

            await _todoContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
