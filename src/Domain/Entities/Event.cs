namespace Domain.Entities
{
    public class Event : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public DateTime EventStartDate { get; set; } = DateTime.Now;
        public DateTime EventEndDate { get; set; } = DateTime.Now;
        public string OrganizationId { get; set; } = string.Empty;
        public string OrganizedByUserId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int SeatAllocation { get; set; } = default;
        public bool IsAvailableForRegistraton { get; set; } = default;
    }
}
