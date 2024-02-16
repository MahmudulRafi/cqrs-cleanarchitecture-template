using Application.Common.DTOs.Response;
using Application.Users.Services;
using Domain.Entities;
using MediatR;

namespace Application.Users.Queries.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ServiceResponse>
    {
        private readonly IUserService _userService;
        public GetAllUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ServiceResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<User> users = await _userService.GetUsersAsync();
                return ServiceResponseHandler.HandleSuccess(users);
            }
            catch (Exception ex)
            {
                return ServiceResponseHandler.HandleError(new List<string> { ex.Message });
            }
        }
    }
}
