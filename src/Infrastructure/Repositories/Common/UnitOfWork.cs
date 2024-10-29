using Domain.Abstractions.Bookings;
using Domain.Abstractions.Common;
using Domain.Abstractions.Events;
using Domain.Abstractions.Organizations;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repositories.Common
{
    public sealed class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;
        private readonly AsyncLocal<IDbContextTransaction?> _currentTransaction = new();
        public IBookingRepository Bookings { get; private set; } = new BookingRepository(context);
        public IEventRepository Events { get; private set; } = new EventRepository(context);
        public IOrganizationRepository Organizations { get; private set; } = new OrganizationRepository(context);

        public void Dispose()
        {
            _context?.Dispose();
            _currentTransaction.Value?.Dispose();
            _currentTransaction.Value = null;
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction.Value is not null)
            {
                return;
            }

            _currentTransaction.Value = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction.Value == null)
            {
                return;
            }

            try
            {
                await SaveChangesAsync(cancellationToken);
                await _currentTransaction.Value.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackTransactionAsync(cancellationToken);
                throw;
            }
            finally
            {
                _currentTransaction.Value?.Dispose();
                _currentTransaction.Value = null;
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction.Value is not null)
            {
                await _currentTransaction.Value.RollbackAsync(cancellationToken);
                _currentTransaction.Value.Dispose();
                _currentTransaction.Value = null;
            }
        }
    }
}
