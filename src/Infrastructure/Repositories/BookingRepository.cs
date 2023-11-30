using Domain.Repositories;
using Domain.Repositories.Common;
using Infrastructure.Repositories.Common;

namespace Infrastructure.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(AppDbContext context) : base(context)
        {
        }
    }
}
