using Domain.Constants;
<<<<<<< HEAD
using Domain.Entities.Common;
=======
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
<<<<<<< HEAD
    public class Organization : Entity
=======
    public class Organization : BaseEntity
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
<<<<<<< HEAD
=======

        // Navigation properties

        [ForeignKey(nameof(User))]
        public string ReportingUserId { get; set; } = string.Empty;
        public User? User { get; set; }
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
    }
}
