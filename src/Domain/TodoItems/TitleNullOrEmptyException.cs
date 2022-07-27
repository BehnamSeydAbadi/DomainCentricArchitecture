namespace Domain.TodoItems
{
    public class TitleNullOrEmptyException : Exception
    {
        public TitleNullOrEmptyException(string message) : base(message) { }
    }
}