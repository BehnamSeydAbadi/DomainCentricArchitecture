using Application.TodoItems.Commands.Common;
using Application.TodoItems.Commands.DeleteTodoItem;
using Microsoft.EntityFrameworkCore;
using Application.UnitTest.Common;
using Domain.TodoItems;
using FluentAssertions;
using NUnit.Framework;
using MediatR;

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
        public async Task ThrowExceptionWhenTodoItemNotFoundAsync()
        {
            var action = () => _mediator.Send(new DeleteTodoItemCommand(0));

            await action.Should().ThrowAsync<TodoItemNotFoundException>();
        }
    }
}
