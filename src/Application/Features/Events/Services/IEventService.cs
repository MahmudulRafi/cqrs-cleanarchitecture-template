using Domain.Entities;

namespace Application.Features.Events.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetEventsAsync(CancellationToken cancellationToken = default);
    }
}
