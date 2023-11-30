using Domain.Entities;

namespace Application.Services.Events
{
    public interface IEventService
    {
        Task<List<Event>> GetEventsAsync();
    }
}
