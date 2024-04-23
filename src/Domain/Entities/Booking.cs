using Domain.Constants;
using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class Booking : BaseEntity
    {
        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("Event")]
        public string EventId { get; set; } = string.Empty;
        public bool IsConfirmed { get; set; } = default;
        public bool IsCanceledByUser { get; set; } = default;

        // Navigation propertise
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
