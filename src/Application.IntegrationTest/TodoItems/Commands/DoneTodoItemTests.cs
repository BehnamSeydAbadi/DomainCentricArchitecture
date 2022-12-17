using Application.TodoItems.Commands.Common;
using Application.TodoItems.Commands.DoneTodoItem;
using Application.UnitTest.Common;
using Domain.TodoItems;
using FluentAssertions;
using FluentValidation;
using MediatR;
using NUnit.Framework;

namespace Application.UnitTest.TodoItems.Commands
{
    public class DoneTodoItemTests : BaseTest
    {
        private ISender _mediator;

        [SetUp]
        public void Setup() => _mediator = GetService<ISender>();

        [Test]
        public async Task DoneDateShouldBeCorrectDateOfWhenTodoItemGetsDoneAsync()
        {
            //Arange
            var todoItem = new TodoItem(RandomTodoItemTitle);

            var todoContext = GetTodoContext();

            await todoContext.TodoItems.AddAsync(todoItem);
            await todoContext.SaveChangesAsync();


            //Act
            await _mediator.Send(new DoneTodoItemCommand(todoItem.Id));


            //Arange
            todoItem.DoneDate.Should().NotBeNull().And.Be(DateTime.UtcNow.Date);
        }

        [Test]
        public async Task ThrowExceptionWhenTodoItemNotFoundAsync()
        {
            var action = () => _mediator.Send(new DoneTodoItemCommand(0));

            await action.Should().ThrowAsync<ValidationException>();
        }
    }
}
