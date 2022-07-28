using Application.Interfaces;
using Domain.TodoItems;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class TodoContext : DbContext, ITodoContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasKey(t => t.Id);
            modelBuilder.Entity<TodoItem>().Property(t => t.DoneDate).IsRequired(false);
            modelBuilder.Entity<TodoItem>().Property(t => t.DueDate).IsRequired(false);
            modelBuilder.Entity<TodoItem>().Property(t => t.Title).HasMaxLength(Domain.TodoItems.TodoItem.MaximumTitleLength);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=TodoDb;Trusted_Connection=True;");
        }

        public DbSet<TodoItem> TodoItem { get; set; }
    }
}
