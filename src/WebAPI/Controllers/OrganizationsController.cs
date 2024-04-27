using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
using Application.Features.Organizations.Commands;
using Application.Features.Organizations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/v1/Organization/")]
    public sealed class OrganizationsController : ControllerBase
    {
        private readonly ISender _sender;
        public OrganizationsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("GetAll")]
        public async Task<ServiceResponse> GetOrganizations([FromQuery] GetAllOrganizationQuery query, CancellationToken cancellationToken)
        {
            return await _sender.Send(query, cancellationToken);
        }

        [HttpGet("GetById")]
        public async Task<ServiceResponse> GetOrganizationById([FromQuery] GetOrganizationByIdQuery query, CancellationToken cancellationToken)
        {
            return await _sender.Send(query, cancellationToken);
        }

        [HttpPost("Create")]
        public async Task<ServiceResponse> CreateOrganization([FromBody] CreateOrganizationCommand command, CancellationToken cancellationToken)
        {
            return await _sender.Send(command, cancellationToken);
        }

    }
}
