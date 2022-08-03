using Common.Exception;

namespace Domain.TodoItems
{
    public class TitleNullOrEmptyException : Exception, IException
    {
        public TitleNullOrEmptyException() : base("Title is null or empty.") { }
    }
}