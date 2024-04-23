using Domain.Constants;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.Common
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class AuditableEntity
    {
        public Guid AddedBy { get; set; }
        public DateTime AddedDateTime { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
