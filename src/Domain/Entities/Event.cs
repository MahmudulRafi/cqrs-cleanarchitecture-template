using Domain.Constants;
using Domain.Entities.Common;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class Event : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public DateTime EventStartDate { get; set; } = DateTime.Now;
        public DateTime EventEndDate { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int SeatAllocation { get; set; } = default;
        public bool IsAvailableForRegistraton { get; set; } = default;

        // Navigation properties
        public string? OrganizationId { get; set; }
        public virtual Organization? Organization { get; set; } 
        public string? OrganizedByUserId { get; set; }
        public virtual IEnumerable<Booking> Bookings { get; set; } = [];
    }
}
