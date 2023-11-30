using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookingsAsync();
    }
}
