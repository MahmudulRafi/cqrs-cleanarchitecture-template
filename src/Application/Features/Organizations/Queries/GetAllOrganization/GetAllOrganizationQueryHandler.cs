using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
using Application.Features.Organizations.Services;
using Domain.Entities;
using Domain.Models.Responses;

namespace Application.Features.Organizations.Queries.GetAllOrganization
{
    public class GetAllOrganizationQueryHandler(IOrganizationService organizationService) : IQueryHandler<GetAllOrganizationQuery, ServiceResponse>
    {
        private readonly IOrganizationService _organizationService = organizationService;

        public async Task<ServiceResponse> Handle(GetAllOrganizationQuery request, CancellationToken cancellationToken)
        {
            PaginatedResponse<List<Organization>> organizations = await _organizationService.GetOrganizationsAsync(request.PageNumber, request.PageSize, cancellationToken);

            return ServiceResponseHandler.HandleSuccess(organizations);
        }
    }
}
