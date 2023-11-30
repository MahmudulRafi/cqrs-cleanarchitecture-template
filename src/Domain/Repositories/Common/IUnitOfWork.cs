namespace Domain.Repositories.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IBookingRepository Bookings { get; }
        IEventRepository Events { get; }
        IOrganizationRepository Organizations { get; }
    }
}
