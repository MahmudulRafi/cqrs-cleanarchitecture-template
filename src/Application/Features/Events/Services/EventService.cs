using Domain.Entities;
using Domain.Repositories.Common;

namespace Application.Features.Events.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<List<Event>> GetEventsAsync(CancellationToken cancellationToken = default)
        {
            return _unitOfWork.Events.GetItemsAsync(cancellationToken);
        }
    }
}
