using Application.Interfaces;
using FluentValidation;

namespace Application.TodoItems.Commands.UndoneTodoItem
{
    public class UndoneTodoItemCommandValidation : AbstractValidator<UndoneTodoItemCommand>
    {
        private readonly ITodoContext _todoContext;

        public UndoneTodoItemCommandValidation(ITodoContext todoContext)
        {
            _todoContext = todoContext;

            RuleFor(c => c.Id).Must(Any).WithMessage("TodoItem not found.");
        }

        private bool Any(int id) => _todoContext.TodoItems.Any(t => t.Id == id);
    }
}
