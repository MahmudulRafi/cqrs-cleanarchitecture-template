using Application.DTOs.Response;
using Application.Services.Users;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/Users")]
        public async Task<ServiceResponse> GetUsers()
        {
            try
            {
                List<User> users = await _userService.GetUsersAsync();
                return ServiceResponseHandler.HandleSuccess(users);
            }
            catch (Exception ex)
            {
                return ServiceResponseHandler.HandleError(ex.Message);
            }
        }

        [HttpGet("/User/{id}")]
        public async Task<ServiceResponse> GetUserById(Guid id)
        {
            try
            {
                User user = await _userService.GetByIdAsync(id);
                return ServiceResponseHandler.HandleSuccess(user);
            }
            catch (Exception ex)
            {
                return ServiceResponseHandler.HandleError(ex.Message);
            }
        }
    }
}
