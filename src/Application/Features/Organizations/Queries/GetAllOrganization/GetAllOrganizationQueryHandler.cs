using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
using Application.Features.Organizations.Services;
using Domain.Entities;
using Domain.Models;

namespace Application.Features.Organizations.Queries
{
    public class GetAllOrganizationQueryHandler : IQueryHandler<GetAllOrganizationQuery, ServiceResponse>
    {
        private readonly IOrganizationService _organizationService;

        public GetAllOrganizationQueryHandler(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public async Task<ServiceResponse> Handle(GetAllOrganizationQuery request, CancellationToken cancellationToken)
        {
            PaginatedResponse<List<Organization>> organizations = await _organizationService.GetOrganizationsAsync(request.PageNumber, request.PageSize, cancellationToken);

            return ServiceResponseHandler.HandleSuccess(organizations);
        }
    }
}
