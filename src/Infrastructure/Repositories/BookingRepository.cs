using Domain.Abstractions.Bookings;
using Infrastructure.Data;
using Infrastructure.Repositories.Common;

namespace Infrastructure.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(AppDbContext context) : base(context) 
        { 

        }
    }
}
