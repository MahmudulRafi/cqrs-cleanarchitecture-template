namespace Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = "guid_ekta_1", FirstName = "Mahmudul Hasan", LastName = "Rafi" },
                new User { Id = "guid_ekta_2", FirstName = "Mahadi Hasan", LastName = "Rafat" }
                );
        }
    }
}
