namespace Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
