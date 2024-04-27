namespace Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = Guid.NewGuid().ToString(), FirstName = "Mahmudul Hasan", LastName = "Rafi" },
                new User { Id = Guid.NewGuid().ToString(), FirstName = "Mahadi Hasan", LastName = "Rafat" }
                );
        }
    }
}
