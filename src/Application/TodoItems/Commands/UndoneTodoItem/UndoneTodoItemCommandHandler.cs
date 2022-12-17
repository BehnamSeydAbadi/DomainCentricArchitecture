using Application.TodoItems.Commands.Common;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using MediatR;

namespace Application.TodoItems.Commands.UndoneTodoItem
{
    internal sealed class UndoneTodoItemCommandHandler : IRequestHandler<UndoneTodoItemCommand>
    {
        private readonly ITodoContext _todoContext;

        public UndoneTodoItemCommandHandler(ITodoContext todoContext) => _todoContext = todoContext;

        public async Task<Unit> Handle(UndoneTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _todoContext.TodoItems.SingleOrDefaultAsync(t => t.Id == request.Id);

            todoItem.MakeItUndone();

            _todoContext.TodoItems.Update(todoItem);

            await _todoContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
