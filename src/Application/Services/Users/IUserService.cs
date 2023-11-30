using Domain.Entities;

namespace Application.Services.Users
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetByIdAsync(Guid id);
    }
}
