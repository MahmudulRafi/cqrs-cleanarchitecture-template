namespace Domain.Entities
{
    public class Event : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Schedule { get; set; } = DateTime.Now;
        public Guid OrganizationId { get; set; } = default;
        public Guid OrganizedByUserId { get; set; } = default;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int SeatAllocation { get; set; } = default;
        public bool IsAvailable { get; set; } = default;
    }
}
