namespace Domain.Entities
{
    public class Organization : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid ReportingUserId { get; set; } = default;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

    }
}
