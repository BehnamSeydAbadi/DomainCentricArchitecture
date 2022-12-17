using Application.Interfaces;
using FluentValidation;

namespace Application.TodoItems.Commands.DoneTodoItem
{

    public class DoneTodoItemCommandValidator : AbstractValidator<DoneTodoItemCommand>
    {
        private readonly ITodoContext _todoContext;

        public DoneTodoItemCommandValidator(ITodoContext todoContext)
        {
            _todoContext = todoContext;
            
            RuleFor(c => c.Id).Must(Any).WithMessage("TodoItem not found.");
        }

        private bool Any(int id) => _todoContext.TodoItems.Any(t => t.Id == id);
    }
}
