using Domain.Entities;

namespace Application.Services.Bookings
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookingsAsync();
    }
}
