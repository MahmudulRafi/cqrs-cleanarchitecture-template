using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
<<<<<<< HEAD
using Domain.Abstractions.Users.Service;
=======
using Application.Features.Users.Services;
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
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
<<<<<<< HEAD
            List<ApplicationUser> users = await _userService.GetUsersAsync(cancellationToken);
=======
            List<User> users = await _userService.GetUsersAsync(cancellationToken);
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694

            _logger.LogInformation("{Response}", users);

            return ServiceResponseHandler.HandleSuccess(users);
        }
    }
}
