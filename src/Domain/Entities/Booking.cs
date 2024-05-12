using Domain.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class Booking : BaseEntity
    {
        public bool IsConfirmed { get; set; } = default;
        public bool IsCanceledByUser { get; set; } = default;

        // Navigation properties
        
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }


        [ForeignKey(nameof(Event))]
        public string EventId { get; set; } = string.Empty;
        public Event? Event { get; set; }
    }
}
