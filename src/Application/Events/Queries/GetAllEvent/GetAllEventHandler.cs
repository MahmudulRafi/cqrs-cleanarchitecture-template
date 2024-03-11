using Application.Abstractions.Messaging;
using Application.Common.DTOs.Response;
using Application.Events.Services;
using Domain.Entities;

namespace Application.Events.Queries.GetAllEvent
{
    public class GetAllEventHandler : IQueryHandler<GetAllEventQuery, ServiceResponse>
    {
        private readonly IEventService _eventService;

        public GetAllEventHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<ServiceResponse> Handle(GetAllEventQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Event> events = await _eventService.GetEventsAsync(cancellationToken);

                return ServiceResponseHandler.HandleSuccess(events);
            }
            catch (Exception ex)
            {
                return ServiceResponseHandler.HandleError(new List<string> { ex.Message });
            }
        }
    }
}
