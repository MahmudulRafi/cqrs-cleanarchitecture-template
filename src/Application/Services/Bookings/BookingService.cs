using Domain.Entities;
using Domain.Repositories.Common;

namespace Application.Services.Bookings
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Booking>> GetBookingsAsync()
        {
            return await _unitOfWork.Bookings.GetAllAsync();
        }
    }
}
