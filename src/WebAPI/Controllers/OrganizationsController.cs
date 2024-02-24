using Application.Common.DTOs.Response;
using Application.Organizations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrganizationsController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpGet("/Organizations")]
        public async Task<ServiceResponse> GetOrganizations([FromQuery] GetAllOrganizationQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("/Organization")]
        public async Task<ServiceResponse> GetOrganizationById([FromQuery] GetOrganizationByIdQuery query)
        {
            return await _mediator.Send(query);
        }

    }
}
