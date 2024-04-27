using Domain.Models;
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

        public async Task<bool> EntryExists(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(predicate, cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().AsQueryable().ToListAsync(cancellationToken);
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

        public async Task<PaginatedResponse<List<T>>> GetPaginatedResponseAsync(int PageNumber, int PageSize, CancellationToken cancellationToken = default)
        {
            List<T> paginatedResponse = await _dbSet.Skip((PageNumber - 1) * PageSize).Take(PageSize).AsNoTracking().AsQueryable().ToListAsync(cancellationToken);
            
            int totalItemCount = _dbSet.AsNoTracking().AsQueryable().Count();

            return new PaginatedResponse<List<T>>() { Data = paginatedResponse, TotalCount = totalItemCount };
        }
    }
}