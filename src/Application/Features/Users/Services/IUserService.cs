using Domain.Entities;

namespace Application.Features.Users.Services
{
    public interface IUserService
    {
<<<<<<< HEAD
        Task<List<ApplicationUser>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task<ApplicationUser> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<bool> CreateUserAsync(ApplicationUser user, CancellationToken cancellationToken = default);
=======
        Task<List<User>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task<User> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default);
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
        Task<bool> UserEmailExists(string email, CancellationToken cancellationToken = default);
    }
}
