using Infrastructure.Identity.Models;

namespace Infrastructure.Data.Configurations
{
    internal class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(a => a.ReportingUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.Events)
                .WithOne(a => a.Organization)
                .HasForeignKey(e => e.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(a => !a.IsDeleted);

            builder.Ignore(o => o.Members);

            // Seed data

            builder.HasData(new Organization { Id = "4360182a-91b0-4973-8593-ff4163dd1fe7", Name = "My Organization 1", ReportingUserId = "guid_ekta_1", Phone = "01839549584", Email = "org@gmail.com", Members = new List<string> { "He, She", "We, us" } });
            builder.HasData(new Organization { Id = "4360182a-91b0-4973-8593-ff4163dd1fe8", Name = "My Organization 2", ReportingUserId = "guid_ekta_2", Phone = "01839549584", Email = "org@gmail.com", Members = new List<string> { "1, 2", "We, us" } });
            builder.HasData(new Organization { Id = "4360182a-91b0-4973-8593-ff4163dd1fe9", Name = "My Organization 3", ReportingUserId = "guid_ekta_1", Phone = "01839549584", Email = "org1@gmail.com", Members = new List<string> { "He, She", "5, u6" } });

        }
    }
}
