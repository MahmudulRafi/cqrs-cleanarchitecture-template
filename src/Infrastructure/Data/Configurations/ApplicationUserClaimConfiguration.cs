using Infrastructure.Identity.Models;

namespace Infrastructure.Data.Configurations
{
    internal class ApplicationUserClaimConfiguration : IEntityTypeConfiguration<ApplicationUserClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
        {
            builder.ToTable("UserClaims");
        }
    }
}
