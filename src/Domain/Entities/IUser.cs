using Domain.Entities.Common;

namespace Domain.Entities
{
    public interface IUser : IAuditableEntity, IActiveEntity, ISoftDeletableEntity
    { 
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
