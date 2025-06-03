using Application.DTOs.Responses;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Queries.GetAllUser;
using Application.Features.Users.Queries.GetUserById;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/Users")]
<<<<<<< HEAD
    public class UsersController : ControllerBase
=======
    public class UsersController : Controller
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
    {
        private readonly ISender _sender;
        public UsersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ServiceResponse> GetUsers([FromQuery] GetAllUserQuery query, CancellationToken cancellationToken)
        {
            return await _sender.Send(query, cancellationToken);
        }

        [HttpGet("{userId}")]
        public async Task<ServiceResponse> GetUserById(string userId, CancellationToken cancellationToken)
        {
            GetUserByIdQuery query = new() { Id = userId };

            return await _sender.Send(query, cancellationToken);
        }

        [HttpPost]
        public async Task<ServiceResponse> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            return await _sender.Send(command, cancellationToken);
        }

    }
}
