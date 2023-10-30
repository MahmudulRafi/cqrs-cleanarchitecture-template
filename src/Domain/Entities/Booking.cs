namespace Domain.Entities
{
    public class Booking : BaseEntity
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public Guid EventId { get; set; } = Guid.NewGuid();
        public bool IsConfirmed { get; set; } = default;
        public bool IsCanceledByUser { get; set; } = default;
    }
}
