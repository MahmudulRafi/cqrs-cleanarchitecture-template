using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
using Application.Features.Organizations.Commands.CreateOrganization;
using Application.Features.Organizations.Queries;
using Asp.Versioning;
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
        public async Task<ServiceResponse> GetOrganizations([FromQuery] GetAllOrganizationQuery query, CancellationToken cancellationToken)
        {
            return await _sender.Send(query, cancellationToken);
        }

        [HttpGet("{organizationId}")]
        public async Task<ServiceResponse> GetOrganizationById(string organizationId, CancellationToken cancellationToken)
        {
            GetOrganizationByIdQuery query = new() { Id = organizationId };

            return await _sender.Send(query, cancellationToken);
        }

        [HttpPost]
        public async Task<ServiceResponse> CreateOrganization([FromBody] CreateOrganizationCommand command, CancellationToken cancellationToken)
        {
            return await _sender.Send(command, cancellationToken);
        }
    }
}
