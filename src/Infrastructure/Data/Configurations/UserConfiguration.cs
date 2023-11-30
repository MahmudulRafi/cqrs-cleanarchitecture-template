namespace Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = Guid.Parse("be2c400c-a3a0-473d-bd08-10bcbc78c30a"), Name = "Mahmudul Rafi", Email = "test@gmail.com", Phone = "0121231232" },
                new User { Id = Guid.Parse("988aee7b-f174-4d21-acf3-3bec223bbe23"), Name = "Mahadi Hasan Rafat", Email = "test1@gmail.com", Phone = "012123324" }
                );
        }
    }
}
