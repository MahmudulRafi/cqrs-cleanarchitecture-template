using Domain.Constants;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.Common
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class BaseEntity : AuditableEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
