using Domain.Entities;

namespace Application.Users.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task<User> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
