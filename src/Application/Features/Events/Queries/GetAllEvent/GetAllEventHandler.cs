using Application.Abstractions.Messaging;
using Application.Common.DTOs.Response;
using Application.Features.Events.Services;
using Domain.Entities;

namespace Application.Features.Events.Queries.GetAllEvent
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
            List<Event> events = await _eventService.GetEventsAsync(cancellationToken);

            return ServiceResponseHandler.HandleSuccess(events);
        }
    }
}
