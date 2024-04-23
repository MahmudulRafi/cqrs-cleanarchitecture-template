using Domain.Constants;
using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class Organization : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        [ForeignKey("User")]
        public string ReportingUserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        // Navigation propertise
        public User User { get; set; }  

    }
}
