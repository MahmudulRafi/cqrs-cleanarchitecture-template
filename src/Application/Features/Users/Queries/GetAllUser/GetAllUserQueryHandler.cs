using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
using Application.Features.Users.Services;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Features.Users.Queries.GetAllUser
{
    public class GetAllUserQueryHandler : IQueryHandler<GetAllUserQuery, ServiceResponse>
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetAllUserQueryHandler> _logger;
        public GetAllUserQueryHandler(IUserService userService, ILogger<GetAllUserQueryHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<ServiceResponse> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            List<User> users = await _userService.GetUsersAsync(cancellationToken);

            _logger.LogInformation("{Response}", users);

            return ServiceResponseHandler.HandleSuccess(users);
        }
    }
}
