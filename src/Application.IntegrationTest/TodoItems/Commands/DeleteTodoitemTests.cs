using Application.TodoItems.Commands.DeleteTodoItem;
using Microsoft.EntityFrameworkCore;
using Application.UnitTest.Common;
using Domain.TodoItems;
using FluentAssertions;
using NUnit.Framework;
using MediatR;
using FluentValidation;

namespace Application.UnitTest.TodoItems.Commands
{
    public class DeleteTodoItemTests : BaseTest
    {
        private ISender _mediator;

        [SetUp]
        public void Setup() => _mediator = GetService<ISender>();

        [Test]
        public async Task DeleteTodoItemSuccessfullyAsync()
        {
            //Arange
            var todoItem = new TodoItem(RandomTodoItemTitle);

            var todoContext = GetTodoContext();

            await todoContext.TodoItems.AddAsync(todoItem);
            await todoContext.SaveChangesAsync();


            //Act
            await _mediator.Send(new DeleteTodoItemCommand(todoItem.Id));


            //Assert
            var todoItems = await todoContext.TodoItems.ToListAsync();
            todoItems.Should().BeEmpty();
        }

        [Test]
        public void ThrowExceptionWhenTodoItemNotFound()
        {
            var command = new DeleteTodoItemCommand(0);
            var action = () => _mediator.Send(command);

            FluentActions.Invoking(action).Should().ThrowAsync<ValidationException>();
        }
    }
}
