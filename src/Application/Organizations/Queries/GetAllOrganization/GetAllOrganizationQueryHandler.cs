using Application.Abstractions.Messaging;
using Application.Common.DTOs.Response;
using Application.Organizations.Services;
using Domain.Entities;

namespace Application.Organizations.Queries.GetAllOrganization
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
            try
            {
                List<Organization> organizations = await _organizationService.GetOrganizationsAsync(cancellationToken);

                return ServiceResponseHandler.HandleSuccess(organizations);
            }
            catch (Exception ex)
            {
                return ServiceResponseHandler.HandleError(new List<string> { ex.Message });
            }
        }
    }
}
