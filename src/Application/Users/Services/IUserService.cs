using Domain.Entities;

namespace Application.Users.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetByIdAsync(string id);
    }
}
