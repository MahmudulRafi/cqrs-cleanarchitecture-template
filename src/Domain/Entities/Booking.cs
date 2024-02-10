namespace Domain.Entities
{
    public class Booking : BaseEntity
    {
        public string UserId { get; set; } = string.Empty;  
        public string EventId { get; set; } = string.Empty;
        public bool IsConfirmed { get; set; } = default;
        public bool IsCanceledByUser { get; set; } = default;
    }
}
