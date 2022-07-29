using Faker;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.UnitTest.Common
{
    public abstract class BaseTest
    {
        protected TodoContext _todoContext;

        public BaseTest() => SetTodoContext();

        protected string RandomTodoItemTitle => Name.FullName(NameFormats.WithPrefix);



        private void SetTodoContext()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "TodoDb")
                .Options;

            _todoContext = new TodoContext(options);
        }
    }
}
