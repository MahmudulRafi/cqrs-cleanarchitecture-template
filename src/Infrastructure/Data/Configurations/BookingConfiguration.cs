using Infrastructure.Identity.Models;

namespace Infrastructure.Data.Configurations
{
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Event)
                .WithMany(a => a.Bookings)
                .HasForeignKey(a => a.EventId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(a => !a.IsDeleted);
        }
    }
}
