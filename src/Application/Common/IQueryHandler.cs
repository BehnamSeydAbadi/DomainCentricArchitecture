namespace Application.Common
{
    public interface IQueryHandler<ViewModel>
    {
        Task<ViewModel[]> HandleAsync();
    }
}
