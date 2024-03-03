namespace Domain.Repositories.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
