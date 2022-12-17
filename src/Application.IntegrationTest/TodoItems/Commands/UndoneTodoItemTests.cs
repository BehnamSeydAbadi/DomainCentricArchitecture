using Application.TodoItems.Commands.UndoneTodoItem;
using Application.UnitTest.Common;
using Domain.TodoItems;
using FluentAssertions;
using NUnit.Framework;
using MediatR;
using FluentValidation;

namespace Application.UnitTest.TodoItems.Commands
{
    public class UndoneTodoItemTests : BaseTest
    {
        private ISender _mediator;

        [SetUp]
        public void Setup() => _mediator = GetService<ISender>();

        [Test]
        public async Task DoneDateShouldBeNullWhenTodoItemGetsUndoneAsync()
        {
            //Arange
            var todoItem = new TodoItem(RandomTodoItemTitle);

            var todoContext = GetTodoContext();

            await todoContext.TodoItems.AddAsync(todoItem);
            await todoContext.SaveChangesAsync();


            //Act
            await _mediator.Send(new UndoneTodoItemCommand(todoItem.Id));


            //Arange
            todoItem.DoneDate.Should().BeNull();
        }

        [Test]
        public async Task ThrowExceptionWhenTodoItemNotFoundAsync()
        {
            var action = () => _mediator.Send(new UndoneTodoItemCommand(0));

            await action.Should().ThrowAsync<ValidationException>();
        }
    }
}
