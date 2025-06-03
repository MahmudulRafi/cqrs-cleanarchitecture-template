using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    internal class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            // Seed data

            builder.HasData(new Organization { Id = Guid.NewGuid(), Name = "My Organization 1", Phone = "01343434443", Email = "org@gmail.com" });
            builder.HasData(new Organization { Id = Guid.NewGuid(), Name = "My Organization 2", Phone = "01839344343", Email = "org@gmail.com" });
            builder.HasData(new Organization { Id = Guid.NewGuid(), Name = "My Organization 3", Phone = "01843434343", Email = "org1@gmail.com" });

        }
    }
}
