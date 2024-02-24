namespace Infrastructure.Data.Configurations
{
    internal class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasData(new Organization { Id = "4360182a-91b0-4973-8593-ff4163dd1fe7", Name = "My Organization", ReportingUserId = Guid.NewGuid().ToString(), Phone = "01839549584", Email = "org@gmail.com" });
        }
    }
}
