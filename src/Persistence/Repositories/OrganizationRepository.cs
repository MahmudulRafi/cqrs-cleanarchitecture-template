using Domain.Entities;
using Domain.Interfaces.Organizations;
using Persistence.Data;
using Persistence.Repositories.Common;

namespace Persistence.Repositories
{
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(ApplicationDatabaseContext context) : base(context)
        {

        }
    }
}
