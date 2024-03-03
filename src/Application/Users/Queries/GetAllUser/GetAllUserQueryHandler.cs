using Application.Abstractions.Messaging;
using Application.Common.DTOs.Response;
using Application.Users.Services;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Users.Queries.GetAllUser
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
            try
            {
                List<User> users = await _userService.GetUsersAsync(cancellationToken);

                _logger.LogInformation("{@handlerName} response - {@response}", nameof(GetAllUserQueryHandler), users);
               
                return ServiceResponseHandler.HandleSuccess(users);

            }
            catch (Exception ex)
            {
                return ServiceResponseHandler.HandleError(new List<string> { ex.Message });
            }
        }
    }
}
