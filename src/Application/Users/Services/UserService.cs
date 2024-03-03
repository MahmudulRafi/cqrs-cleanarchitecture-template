using Domain.Entities;
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

        public async Task<User> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Users.GetByIdAsync(id, cancellationToken);
        }

        public async Task<List<User>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Users.GetAllAsync(cancellationToken);
        }
    }
}
