namespace Domain.TodoItems
{
    public class TitleNullOrEmptyException : Exception
    {
        public TitleNullOrEmptyException() : base("Title is null or empty.") { }
    }
}