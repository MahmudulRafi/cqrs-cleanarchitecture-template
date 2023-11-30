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
        public async Task<List<User>> GetUsers()
        {
            return await _userService.GetUsersAsync();
        }

        [HttpGet("/User/{id}")]
        public async Task<User> GetUserById(Guid id)
        {
            return await _userService.GetByIdAsync(id);
        }
    }
}
