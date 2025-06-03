using Domain.Entities;

namespace Application.Features.Bookings.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookingsAsync();
    }
}
