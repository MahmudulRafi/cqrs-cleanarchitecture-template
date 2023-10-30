namespace Domain.Common
{
    public class BaseEntity : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
