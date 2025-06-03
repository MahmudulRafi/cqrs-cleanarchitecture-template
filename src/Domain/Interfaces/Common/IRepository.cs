using Domain.Entities.Common;
using Domain.Models.Requests;
using Domain.Models.Responses;
using System.Linq.Expressions;

namespace Domain.Interfaces.Common
{
    public interface IRepository<T> where T : Entity
    {
        /// <summary>
        /// Get queryable for specific entity of type(T)
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetQueryable();
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
        Task<PaginatedResponse<List<T>>> GetItemsAsync(QueryableRequest<T> request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get item by Id of entity of type(T)
        /// </summary>
        /// <param name="id">T entity Id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Entity T</returns>
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add new entity of type(T)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Entity T</returns>
        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks entry exists or not
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>a bool value</returns>
        Task<bool> EntryExists(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add multiple entities of type(T)
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>List of added entities</returns>
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update an existing entity of type(T)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Updated entity</returns>
        void Update(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update multiple existing entities of type(T)
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>List of updated entities</returns>
        void UpdateRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete an entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if deleted successfully</returns>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if deleted successfully</returns>
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete multiple entities
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if all entities deleted successfully</returns>
        Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get entities based on a predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>List of entities matching the predicate</returns>
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get first entity matching a predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>First matching entity or null</returns>
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get single entity matching a predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Single matching entity or throws if multiple matches found</returns>
        Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Count entities matching a predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Count of matching entities</returns>
        Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get entities with included related entities
        /// </summary>
        /// <param name="includes">Related entities to include</param>
        /// <param name="cancellationToken"></param>
        /// <returns>List of entities with included related entities</returns>
        Task<List<T>> GetWithIncludesAsync(Expression<Func<T, object>>[] includes, CancellationToken cancellationToken = default);

        /// <summary>
        /// Execute raw SQL query
        /// </summary>
        /// <param name="sql">SQL query string</param>
        /// <param name="parameters">Query parameters</param>
        /// <param name="cancellationToken"></param>
        /// <returns>List of entities matching the query</returns>
        Task<List<T>> FromSqlAsync(string sql, object[] parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Attach an entity to the context
        /// </summary>
        /// <param name="entity">Entity to attach</param>
        void Attach(T entity);

        /// <summary>
        /// Detach an entity from the context
        /// </summary>
        /// <param name="entity">Entity to detach</param>
        void Detach(T entity);

        /// <summary>
        /// Reload an entity from the database
        /// </summary>
        /// <param name="entity">Entity to reload</param>
        void Reload(T entity);
    }
}
