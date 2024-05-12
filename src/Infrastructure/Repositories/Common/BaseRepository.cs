using Domain.Models.Requests;
using Domain.Models.Responses;
using Domain.Repositories.Common;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetItemsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().AsQueryable().ToListAsync(cancellationToken);
        }
        public async Task<PaginatedResponse<List<T>>> GetItemsAsync(FilteredItemRequest<T> request, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet.AsNoTracking().AsQueryable();

            if (request.Filter is not null)
            {
                query = query.Where(request.Filter);
            }

            if (request.Includes is not null)
            {
                foreach (var include in request.Includes)
                {
                    query = query.Include(include);
                }
            }

            int totalItemCount = query.Count();


            if (request.OrderBy is not null)
            {
                query = request.OrderBy(query);
            }

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);
            }

            List<T> paginatedResponse = await query.ToListAsync(cancellationToken);

            return new PaginatedResponse<List<T>>(data: paginatedResponse, totalCount: totalItemCount);
        }
        public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }
        public async Task<bool> EntryExists(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(predicate, cancellationToken);
        }

    }
}