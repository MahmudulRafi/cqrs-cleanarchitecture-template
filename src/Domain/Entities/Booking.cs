using Domain.Constants;
using Domain.Entities.Common;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class Booking : BaseEntity
    {
        public DateTime BookedOn { get; set; }
        public bool IsConfirmed { get; set; } = default;
        public bool IsCanceledByUser { get; set; } = default;

        // Navigation properties
        public string? UserId { get; set; }
        public string? EventId { get; set; }
        public virtual Event? Event { get; set; }    
    }
}
