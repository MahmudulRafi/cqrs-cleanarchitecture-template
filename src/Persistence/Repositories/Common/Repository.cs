using Domain.Entities.Common;
using Domain.Exceptions;
using Domain.Interfaces.Common;
using Domain.Models.Requests;
using Domain.Models.Responses;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Linq.Expressions;

namespace Persistence.Repositories.Common
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly DbSet<T> _dbSet;
        private readonly ApplicationDatabaseContext _context;

        public Repository(ApplicationDatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<List<T>> GetItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsQueryable().ToListAsync(cancellationToken);
        }

        public async Task<PaginatedResponse<List<T>>> GetItemsAsync(QueryableRequest<T> request, CancellationToken cancellationToken = default)
        {
            try
            {
                IQueryable<T> query = _dbSet.AsQueryable();

                if (request.Filter is not null)
                {
                    query = query.Where(request.Filter);
                }

                if (request.Includes is not null && request.Includes.Any())
                {
                    foreach (var include in request.Includes)
                    {
                        query = query.Include(include);
                    }
                }

                int totalItemCount = await query.CountAsync(cancellationToken);

                if (request.OrderBy is not null)
                {
                    query = request.OrderBy(query);
                }

                if (request.PageNumber > 0 && request.PageSize > 0)
                {
                    query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);
                }

                List<T> paginatedResponse = await query.ToListAsync(cancellationToken);

                return new PaginatedResponse<List<T>>(Data: paginatedResponse, TotalCount: totalItemCount);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error retrieving paginated entities: {ex.Message}", ex);
            }
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await _dbSet.FindAsync([id], cancellationToken);

                if (entity == null)
                {
                    throw new EntityNotFoundException($"Entity with ID {id} not found");
                }

                return entity;
            }
            catch (Exception ex) when (!(ex is EntityNotFoundException))
            {
                throw new RepositoryException($"Error retrieving entity by id: {ex.Message}", ex);
            }
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbSet.AddAsync(entity, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error adding entity: {ex.Message}", ex);
            }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbSet.AddRangeAsync(entities, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error adding entities: {ex.Message}", ex);
            }
        }

        public void Update(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;

                _dbSet.Update(entity);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error updating entity: {ex.Message}", ex);
            }
        }

        public void UpdateRange(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            try
            {
                _dbSet.UpdateRange(entities);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error updating entities: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await GetByIdAsync(id, cancellationToken);

                _dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error deleting entity: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbSet.Where(a => a.Id == entity.Id).ExecuteUpdateAsync(a => a.SetProperty(prop => prop.IsDeleted, true));
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error deleting entity: {ex.Message}", ex);
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            try
            {
                Guid[] deleteableIds = entities.Select(x => x.Id).ToArray();

                await _dbSet.Where(a => deleteableIds.Contains(a.Id)).ExecuteUpdateAsync(a => a.SetProperty(prop => prop.IsDeleted, true));
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error deleting entities: {ex.Message}", ex);
            }
        }

        public async Task<bool> EntryExists(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.AnyAsync(predicate, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error checking entity existence: {ex.Message}", ex);
            }
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error finding entities: {ex.Message}", ex);
            }
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error retrieving first entity: {ex.Message}", ex);
            }
        }

        public async Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.SingleOrDefaultAsync(predicate, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error retrieving single entity: {ex.Message}", ex);
            }
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                if (predicate == null)
                    return await _dbSet.CountAsync(cancellationToken);

                return await _dbSet.CountAsync(predicate, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error counting entities: {ex.Message}", ex);
            }
        }

        public async Task<List<T>> GetWithIncludesAsync(Expression<Func<T, object>>[] includes, CancellationToken cancellationToken = default)
        {
            try
            {
                var query = _dbSet.AsQueryable();

                if (includes != null)
                {
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
                }

                return await query.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error retrieving entities with includes: {ex.Message}", ex);
            }
        }

        public async Task<List<T>> FromSqlAsync(string sql, object[] parameters, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.FromSqlRaw(sql, parameters).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error executing raw SQL query: {ex.Message}", ex);
            }
        }

        public void Attach(T entity)
        {
            _context.Attach(entity);
        }

        public void Detach(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public void Reload(T entity)
        {
            _context.Entry(entity).Reload();
        }
    }
}