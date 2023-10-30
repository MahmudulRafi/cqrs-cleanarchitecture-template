namespace Domain.Common
{
    public class AuditableEntity
    {
        public Guid AddedBy { get; set; } = Guid.NewGuid();
        public DateTime AddedDateTime { get; set; } = DateTime.UtcNow;
        public Guid UpdateBy { get; set; } = Guid.NewGuid();
        public DateTime UpdateDateTime { get; set; } = DateTime.UtcNow;
    }
}
