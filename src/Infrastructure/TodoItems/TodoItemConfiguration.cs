using Domain.TodoItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TodoItems
{
    internal class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public static TodoItemConfiguration Config => new TodoItemConfiguration();

        private TodoItemConfiguration() { }

        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.DoneDate).IsRequired(false);
            builder.Property(t => t.DueDate).IsRequired(false);
            builder.Property(t => t.Title).HasMaxLength(TodoItem.MaximumTitleLength);
        }
    }
}
