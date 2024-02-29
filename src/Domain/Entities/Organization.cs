using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
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
