using Domain.TodoItems;
using Faker;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.UnitTest.TodoItems.Queries
{
    public class TodoItemTests
    {
        private string RandomTodoItemTitle => Name.FullName(NameFormats.WithPrefix);
        private DateTime RandomTodoItemDueDate => Identification.DateOfBirth().Date;

        private TodoContext _todoContext;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "TodoDb")
                .Options;

            _todoContext = new TodoContext(options);

            InsertFakeTodoItems();
        }

        [Test]
        public void GetTodayTodoItemsSuccessfully()
        {
            //Arrange


            _todoContext.TodoItems.Add();
        }


        private void InsertFakeTodoItems()
        {
            for (int i = 0; i < 500; i++)
            {
                var todoItem = new TodoItem(RandomTodoItemTitle);

                todoItem.SetDueDate(RandomTodoItemDueDate);

                _todoContext.TodoItems.Add(todoItem);
            }

            _todoContext.SaveChanges();
        }
    }
}
