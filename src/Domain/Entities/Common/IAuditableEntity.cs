namespace Domain.Entities.Common
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedDateTime { get; set; }
        string LastUpdatedBy { get; set; }
        DateTime? LastUpdatedDateTime { get; set; }
    }
}
