using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class ApplicationUserClaim : IdentityUserClaim<Guid>
    {
        public virtual ApplicationUser? User { get; set; }
    }
}
