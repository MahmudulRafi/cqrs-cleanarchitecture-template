namespace Domain.Entities
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedDateTime { get; set; }
        string LastUpdatedBy { get; set; }
        DateTime? LastUpdatedDateTime { get; set; }
        bool IsDeleted { get; set; }
    }
}
