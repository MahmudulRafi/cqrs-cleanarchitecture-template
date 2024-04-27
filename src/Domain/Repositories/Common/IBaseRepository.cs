using Domain.Entities;
using Domain.Models;
using System.Linq.Expressions;

namespace Domain.Repositories.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PaginatedResponse<List<T>>> GetPaginatedResponseAsync(int PageNumber, int PageSize, CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<bool> EntryExists(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
