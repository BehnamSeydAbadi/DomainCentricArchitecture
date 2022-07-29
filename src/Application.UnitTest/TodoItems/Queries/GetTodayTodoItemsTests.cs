using Application.TodoItems.Queries;
using Domain.TodoItems;
using Faker;
using FluentAssertions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.UnitTest.TodoItems.Queries
{
    public class GetTodayTodoItemsTests
    {
        private GetTodayTodoItemsQueryHandler _queryHandler;
        private TodoContext _todoContext;

        private string RandomTodoItemTitle => Name.FullName(NameFormats.WithPrefix);


        [SetUp]
        public void Setup()
        {
            var todoContext = GetTodoContext();

            _queryHandler = new GetTodayTodoItemsQueryHandler(todoContext);

            _todoContext = todoContext;
        }

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


        private TodoContext GetTodoContext()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                            .UseInMemoryDatabase(databaseName: "TodoDb")
                            .Options;

            return new TodoContext(options);
        }
    }
}
