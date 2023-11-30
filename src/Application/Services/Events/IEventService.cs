using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetEventsAsync();
    }
}
