using FluentValidation;
using Application.Interfaces;

namespace Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommandValidator : AbstractValidator<DeleteTodoItemCommand>
    {
        private readonly ITodoContext _todoContext;

        public DeleteTodoItemCommandValidator(ITodoContext todoContext)
        {
            _todoContext = todoContext;

            RuleFor(c => c.Id).Must(Any).WithMessage("TodoItem not found.");
        }

        private bool Any(int id) => _todoContext.TodoItems.Any(t => t.Id == id);
    }
}
