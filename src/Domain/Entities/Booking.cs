namespace Domain.Entities
{
    public class Booking : BaseAuditableEntity
    {
        public Guid UserId { get; set; } = default;
        public Guid EventId { get; set; } = default;
        public bool IsConfirmed { get; set; } = default;
    }
}
