<<<<<<< HEAD
﻿namespace Domain.Entities.Common
=======
﻿namespace Domain.Entities
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedDateTime { get; set; }
        string LastUpdatedBy { get; set; }
        DateTime? LastUpdatedDateTime { get; set; }
<<<<<<< HEAD
=======
        bool IsDeleted { get; set; }
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
    }
}
