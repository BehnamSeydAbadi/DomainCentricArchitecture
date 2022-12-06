using Application.TodoItems.Queries.GetTodayTodoItems;
using Application.UnitTest.Common;
using Domain.TodoItems;
using FluentAssertions;
using NUnit.Framework;
using MediatR;

namespace Application.UnitTest.TodoItems.Queries
{
    public class GetTodayTodoItemsTests : BaseTest
    {
        private ISender _mediator;

        [SetUp]
        public void Setup() => _mediator = GetService<ISender>();

        [Test]
        public async Task GetTodayTodoItemsSuccessfullyAsync()
        {
            //Arange
            var todoyTodoItem = new TodoItem(RandomTodoItemTitle);
            todoyTodoItem.SetDueDate(DateTime.Today.Date);

            var todoContext = GetTodoContext();

            await todoContext.TodoItems.AddAsync(todoyTodoItem);
            await todoContext.SaveChangesAsync();

            //Act
            var todayTodoItems = await _mediator.Send(GetTodayTodoItemsQuery.Default);

            //Assert
            todayTodoItems.Should().NotBeNullOrEmpty();
        }
    }
}
