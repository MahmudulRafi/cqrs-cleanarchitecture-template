using Domain.Entities;

namespace Application.Features.Users.Services
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task<ApplicationUser> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<bool> CreateUserAsync(ApplicationUser user, CancellationToken cancellationToken = default);
        Task<bool> UserEmailExists(string email, CancellationToken cancellationToken = default);
    }
}
