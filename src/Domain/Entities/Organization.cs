using Domain.Constants;
using Domain.Entities.Common;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class Organization : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<string> Members { get; set; } = [];

        // Navigation properties
        public string? ReportingUserId { get; set; }
        public virtual IEnumerable<Event> Events { get; set; } = [];
    }
}
