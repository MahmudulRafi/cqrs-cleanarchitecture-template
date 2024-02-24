using Application.Common.DTOs.Response;
using Application.Organizations.Services;
using Domain.Entities;
using MediatR;

namespace Application.Organizations.Queries.Handlers
{
    public class GetAllOrganizationQueryHandler : IRequestHandler<GetAllOrganizationQuery, ServiceResponse>
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
                List<Organization> organizations = await _organizationService.GetOrganizationsAsync();
                return ServiceResponseHandler.HandleSuccess(organizations);
            }
            catch (Exception ex)
            {
                return ServiceResponseHandler.HandleError(new List<string> { ex.Message });
            }
        }
    }
}
