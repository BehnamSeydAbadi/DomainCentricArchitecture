using Application.Interfaces;
using Application.TodoItems.Commands.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoItems.Commands.DoneTodoItem
{
    internal sealed class DoneTodoItemCommandHandler : IRequestHandler<DoneTodoItemCommand>
    {
        private readonly ITodoContext _todoContext;

        public DoneTodoItemCommandHandler(ITodoContext todoContext) => _todoContext = todoContext;

        public async Task<Unit> Handle(DoneTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _todoContext.TodoItems.SingleOrDefaultAsync(t => t.Id == request.Id);

            todoItem.MakeItDone();

            _todoContext.TodoItems.Update(todoItem);

            await _todoContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
