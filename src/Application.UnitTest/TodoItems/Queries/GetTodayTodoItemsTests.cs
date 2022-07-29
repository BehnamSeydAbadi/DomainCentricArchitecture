using Application.TodoItems.Queries;
using Application.UnitTest.Common;
using Domain.TodoItems;
using FluentAssertions;
using NUnit.Framework;

namespace Application.UnitTest.TodoItems.Queries
{
    public class GetTodayTodoItemsTests : BaseTest
    {
        private GetTodayTodoItemsQueryHandler _queryHandler;

        [SetUp]
        public void Setup() => _queryHandler = new GetTodayTodoItemsQueryHandler(_todoContext);

        [Test]
        public async Task GetTodayTodoItemsSuccessfullyAsync()
        {
            //Arange
            var todoyTodoItem = new TodoItem(RandomTodoItemTitle);
            todoyTodoItem.SetDueDate(DateTime.Today.Date);

            await _todoContext.TodoItems.AddAsync(todoyTodoItem);
            await _todoContext.SaveChangesAsync();

            //Act
            var todayTodoItems = await _queryHandler.HandleAsync();

            //Assert
            todayTodoItems.Should().NotBeNullOrEmpty();
        }
    }
}
