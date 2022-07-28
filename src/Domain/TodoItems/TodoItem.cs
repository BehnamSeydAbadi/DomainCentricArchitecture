using Domain.Common;

namespace Domain.TodoItems
{
    public sealed class TodoItem : Entity
    {
        public static int MaximumTitleLength => 512;

        public TodoItem(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new TitleNullOrEmptyException();

            if (title.Length > 512)
                throw new InvalidTitleLengthException();

            Title = title;
        }

        public string Title { get; }
        public bool IsDone { get; private set; }
        public DateTime? DoneDate { get; private set; }
        public DateTime? DueDate { get; private set; }

        public void MakeItDone()
        {
            IsDone = true;
            DoneDate = DateTime.UtcNow.Date;
        }

        public void MakeItUndone()
        {
            IsDone = false;
            DoneDate = null;
        }

        public void SetDueDate(DateTime dueDate) => DueDate = dueDate;
    }
}
