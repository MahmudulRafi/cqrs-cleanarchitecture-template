using Domain.Entities;

namespace Domain.Repositories.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IOrganizationRepository Organizations { get; }
        IEventRepository Events { get; }
        IBookingRepository Bookings { get; }
        Task<bool> SaveChangesAsync();
    }
}
