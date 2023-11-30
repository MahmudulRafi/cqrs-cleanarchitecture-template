using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Common;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }
    }
}
