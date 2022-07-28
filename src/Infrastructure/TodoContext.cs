using Application.Interfaces;
using Domain.TodoItems;
using Infrastructure.TodoItems;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class TodoContext : DbContext, ITodoContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(TodoItemConfiguration.Config);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=TodoDb;Trusted_Connection=True;");
        }

        public DbSet<TodoItem> TodoItem { get; set; }
    }
}
