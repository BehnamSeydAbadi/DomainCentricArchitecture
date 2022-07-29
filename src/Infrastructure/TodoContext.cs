using Application.Interfaces;
using Domain.TodoItems;
using Infrastructure.TodoItems;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class TodoContext : DbContext, ITodoContext
    {
        public TodoContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfiguration(TodoItemConfiguration.Config);

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.;Database=TodoDb;Trusted_Connection=True;");
        //}

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
