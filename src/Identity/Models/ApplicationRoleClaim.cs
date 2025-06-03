using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual ApplicationRole? Role { get; set; }
    }
}
