using Application.Features.Organizations.Commands.CreateOrganization;
using Application.Features.Organizations.Queries.GetAllOrganization;
using Application.Features.Organizations.Queries.GetOrganizationById;
using Application.Models.Common;
using Asp.Versioning;
using Domain.Entities;
using Domain.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/organizations")]
    public sealed class OrganizationsController : ControllerBase
    {
        private readonly ISender _sender;
        public OrganizationsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<Result<PaginatedResponse<List<Organization>>>> GetOrganizations([FromQuery] GetAllOrganizationQuery query, CancellationToken cancellationToken)
        {
            return await _sender.Send(query, cancellationToken);
        }

        [HttpGet("{organizationId}")]
        public async Task<Result<Organization>> GetOrganizationById(string organizationId, CancellationToken cancellationToken)
        {
            GetOrganizationByIdQuery query = new() { Id = organizationId };

            return await _sender.Send(query, cancellationToken);
        }

        [HttpPost]
        public async Task<Result<Organization>> CreateOrganization([FromBody] CreateOrganizationCommand command, CancellationToken cancellationToken)
        {
            return await _sender.Send(command, cancellationToken);
        }
    }
}
