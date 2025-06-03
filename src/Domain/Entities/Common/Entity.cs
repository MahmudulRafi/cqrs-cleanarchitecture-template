using Domain.Constants;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.Common
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class Entity : IEntity<Guid>, IAuditableEntity, IActiveEntity, ISoftDeletableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; } = string.Empty;
        public DateTime? LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false; 
    }
}
