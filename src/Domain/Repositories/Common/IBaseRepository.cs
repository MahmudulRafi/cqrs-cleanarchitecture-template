using Domain.Entities;
using Domain.Models.Requests;
using Domain.Models.Responses;
using System.Linq.Expressions;

namespace Domain.Repositories.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get all items for specific entity of type(T)
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List<T></returns>
        Task<List<T>> GetItemsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get filtered items for specific entity of type(T)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>PaginatedResponse<List<T>></returns>
        Task<PaginatedResponse<List<T>>> GetItemsAsync(FilteredItemRequest<T> request, CancellationToken cancellationToken = default);
       
        /// <summary>
        /// Get item by Id of entity of type(T)
        /// </summary>
        /// <param name="id">T entity Id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Entity T</returns>
        Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Add new entity of type(T)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Entity T</returns>
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks entry exists or not
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>a bool value</returns>
        Task<bool> EntryExists(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
