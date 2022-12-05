using Application.TodoItems.Commands.CreateTodoItem;
using Microsoft.EntityFrameworkCore;
using Application.UnitTest.Common;
using FluentAssertions;
using NUnit.Framework;
using MediatR;

namespace Application.UnitTest.TodoItems.Commands
{
    public class CreateTodoItemTests : BaseTest
    {
        private ISender _mediator;

        [SetUp]
        public void Setup() => _mediator = GetService<ISender>();

        [Test]
        public async Task CreateTodoItemSuccessfullyAsync()
        {
            //Arange
            var todoItemTitle = RandomTodoItemTitle;

            //Act
            await _mediator.Send(new CreateTodoItemCommand(todoItemTitle));

            //Assert
            var todoItem = await GetTodoContext().TodoItems.SingleOrDefaultAsync();
            todoItem.Title.Should().Be(todoItemTitle);
        }
    }
}
