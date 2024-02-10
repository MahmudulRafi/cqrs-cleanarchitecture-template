using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Common;

namespace Application.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }
    }
}
