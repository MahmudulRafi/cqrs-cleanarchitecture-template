using Domain.Entities;

namespace Application.Bookings.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookingsAsync();
    }
}
