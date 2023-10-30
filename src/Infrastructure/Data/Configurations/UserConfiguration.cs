namespace Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Name = "Mahmudul Rafi", Email = "test@gmail.com", Phone = "0121231232" },
                new User { Name = "Mahadi Hasan Rafat", Email = "test1@gmail.com", Phone = "012123324" }
                );
        }
    }
}
