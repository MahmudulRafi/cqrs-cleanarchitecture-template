using Domain.Abstractions.Common;
using Domain.Abstractions.Users;
using Infrastructure.Identity.Entity;
using Infrastructure.Repositories.Common;

namespace Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : Repository<ApplicationUser>(context), IUserRepository
    {
    }
}
