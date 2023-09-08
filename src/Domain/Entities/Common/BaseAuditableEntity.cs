namespace Domain.Common
{
    public class BaseAuditableEntity : BaseEntity
    {
        public Guid AddedBy { get; set; } = default;
        public DateTime AddedDateTime { get; set; } = DateTime.UtcNow;
        public Guid UpdateBy { get; set; } = default;
        public DateTime UpdateDateTime { get; set; } = DateTime.UtcNow;
    }
}
