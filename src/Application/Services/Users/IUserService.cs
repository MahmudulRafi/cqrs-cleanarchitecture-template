using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
    }
}
