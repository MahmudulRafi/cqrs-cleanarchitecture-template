using Domain.Constants;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class BaseEntity : IAuditableEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; } = string.Empty;
        public DateTime? LastUpdatedDateTime { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
