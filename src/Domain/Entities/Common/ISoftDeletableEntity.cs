namespace Domain.Entities.Common
{
    public interface ISoftDeletableEntity
    {
        bool IsDeleted { get; set; }
    }
}
