using Domain.Repositories;
using Domain.Repositories.Common;

namespace Infrastructure.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext Context { get; set; }
        public IUserRepository Users { get; private set; }
        public IBookingRepository Bookings { get; private set; }
        public IEventRepository Events { get; private set; }
        public IOrganizationRepository Organizations { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            Context = context;
            Users = new UserRepository(Context);
            Bookings = new BookingRepository(Context);
            Events = new EventRepository(Context);
            Organizations = new OrganizationRepository(Context);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
