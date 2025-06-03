<<<<<<< HEAD
﻿using Application.Interfaces.Organizations;
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
=======
﻿using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
using Application.Features.Organizations.Services;
using Domain.Entities;
using Domain.Models.Responses;

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
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
        }
    }
}
