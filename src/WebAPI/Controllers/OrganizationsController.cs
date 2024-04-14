using Application.Abstractions.Messaging;
using Application.Common.DTOs.Response;
using Application.Features.Organizations.Queries.GetAllOrganization;
using Application.Features.Organizations.Queries.GetOrganizationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly ISender _sender;
        public OrganizationsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("/Organizations")]
        public async Task<ServiceResponse> GetOrganizations([FromQuery] GetAllOrganizationQuery query, CancellationToken cancellationToken)
        {
            return await _sender.Send(query, cancellationToken);
        }

        [HttpGet("/Organization")]
        public async Task<ServiceResponse> GetOrganizationById([FromQuery] GetOrganizationByIdQuery query, CancellationToken cancellationToken)
        {
            return await _sender.Send(query, cancellationToken);
        }

    }
}
