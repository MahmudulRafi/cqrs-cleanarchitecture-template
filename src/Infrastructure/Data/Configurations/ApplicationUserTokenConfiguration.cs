using Infrastructure.Identity.Models;

namespace Infrastructure.Data.Configurations
{
    internal class ApplicationUserTokenConfiguration : IEntityTypeConfiguration<ApplicationUserToken>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
        {
            builder.ToTable("UserTokens");
        }
    }
}
