using Application.Common.DTOs.Response;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/Users")]
        public async Task<ServiceResponse> GetUsers([FromQuery] GetAllUsersQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("/User")]
        public async Task<ServiceResponse> GetUserById([FromQuery] GetUserByIdQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
