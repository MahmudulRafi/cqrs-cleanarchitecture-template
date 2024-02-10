namespace Domain.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ReportingUserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

    }
}
