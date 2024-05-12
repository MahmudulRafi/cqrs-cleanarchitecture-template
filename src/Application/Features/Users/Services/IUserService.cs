using Domain.Entities;

namespace Application.Features.Users.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task<User> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default);
        Task<bool> UserEmailExists(string email, CancellationToken cancellationToken = default);
    }
}
