using Domain.Constants;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class User : IdentityUser, IAuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; } = string.Empty;
        public DateTime? LastUpdatedDateTime { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
