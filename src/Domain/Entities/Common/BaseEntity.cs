namespace Domain.Common
{
    public class BaseEntity : AuditableEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
