using Domain.Constants;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.Common
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class AuditableEntity : IAuditableEntity
    {
        public string AddedBy { get; set; } = string.Empty;
        public DateTime AddedDateTime { get; set; }
        public string UpdateBy { get; set; } = string.Empty;
        public DateTime UpdateDateTime { get; set; }
    }
}
