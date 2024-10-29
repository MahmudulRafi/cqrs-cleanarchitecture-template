using Infrastructure.Identity.Models;

namespace Infrastructure.Data.Configurations
{
    internal class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.ToTable("UserRoles");
        }
    }
}
