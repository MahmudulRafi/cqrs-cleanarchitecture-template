<<<<<<< HEAD
﻿using Domain.Abstractions.Common;
=======
﻿using Domain.Entities;
using Domain.Repositories.Common;
using System.Linq.Expressions;
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694

namespace Application.Features.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

<<<<<<< HEAD
        public async Task<bool> CreateUserAsync(ApplicationUser user, CancellationToken cancellationToken = default)
=======
        public async Task<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default)
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
        {
            //await _unitOfWork.Users.InsertAsync(user, cancellationToken);
            //return await _unitOfWork.SaveChangesAsync();

            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public async Task<ApplicationUser> GetByIdAsync(string id, CancellationToken cancellationToken = default)
=======
        public async Task<User> GetByIdAsync(string id, CancellationToken cancellationToken = default)
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
        {
            //return await _unitOfWork.Users.GetByIdAsync(id, cancellationToken);

            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public async Task<List<ApplicationUser>> GetUsersAsync(CancellationToken cancellationToken = default)
=======
        public async Task<List<User>> GetUsersAsync(CancellationToken cancellationToken = default)
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
        {
            //return await _unitOfWork.Users.GetAllAsync(cancellationToken);

            throw new NotImplementedException();
        }

        public async Task<bool> UserEmailExists(string email, CancellationToken cancellationToken = default)
        {
            //Expression<Func<User, bool>> filter = a => a.Email == email;

            //bool response = await _unitOfWork.Users.EntryExists(filter, cancellationToken);

            //return response;

            throw new NotImplementedException();
        }
    }
}
