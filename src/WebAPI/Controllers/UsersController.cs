using Application.Common.DTOs.Response;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetAllUser;
using Application.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/v1/User/")]
    public class UsersController : Controller
    {
        private readonly ISender _sender;
        public UsersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("GetAll")]
        public async Task<ServiceResponse> GetUsers([FromQuery] GetAllUserQuery query, CancellationToken cancellationToken)
        {
            return await _sender.Send(query, cancellationToken);
        }

        [HttpGet("GetById")]
        public async Task<ServiceResponse> GetUserById([FromQuery] GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            return await _sender.Send(query, cancellationToken);
        }

        [HttpPost("Create")]
        public async Task<ServiceResponse> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            return await _sender.Send(command, cancellationToken);
        }

    }
}
