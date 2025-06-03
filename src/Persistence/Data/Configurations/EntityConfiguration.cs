using Microsoft.EntityFrameworkCore;

namespace Persistence.Data.Configurations
{
    public static class EntityConfiguration
    {
        public static void ApplyEntityConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
        }
    }
}
