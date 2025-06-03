namespace Domain.Entities.Common
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }   
    }
}
