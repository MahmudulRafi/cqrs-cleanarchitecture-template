using Application.Common.DTOs.Response;
using Application.Users.Queries.GetAllUser;
using Application.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ISender _sender;
        public UsersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("/Users")]
        public async Task<ServiceResponse> GetUsers([FromQuery] GetAllUserQuery query, CancellationToken cancellationToken)
        {
            return await _sender.Send(query, cancellationToken);
        }

        [HttpGet("/User")]
        public async Task<ServiceResponse> GetUserById([FromQuery] GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            return await _sender.Send(query, cancellationToken);
        }
    }
}
