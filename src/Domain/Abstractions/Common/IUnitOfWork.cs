using Domain.Abstractions.Bookings;
using Domain.Abstractions.Events;
using Domain.Abstractions.Organizations;

namespace Domain.Abstractions.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IOrganizationRepository Organizations { get; }
        IEventRepository Events { get; }
        IBookingRepository Bookings { get; }
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
