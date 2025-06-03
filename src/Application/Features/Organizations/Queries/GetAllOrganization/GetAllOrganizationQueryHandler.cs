using Application.Interfaces.Organizations;
using Application.Models.Common;
using Application.Shared.Interfaces.Messaging;
using Domain.Entities;
using Domain.Models.Responses;

namespace Application.Features.Organizations.Queries.GetAllOrganization
{
    public class GetAllOrganizationQueryHandler(IOrganizationService organizationService) : IQueryHandler<GetAllOrganizationQuery, Result<PaginatedResponse<List<Organization>>>>
    {
        private readonly IOrganizationService _organizationService = organizationService;

        public async Task<Result<PaginatedResponse<List<Organization>>>> Handle(GetAllOrganizationQuery request, CancellationToken cancellationToken)
        {
            PaginatedResponse<List<Organization>> organizations = await _organizationService.GetOrganizationsAsync(request.PageNumber, request.PageSize, cancellationToken);

            return ResponseHandler.HandleSuccess(organizations);
        }
    }
}
