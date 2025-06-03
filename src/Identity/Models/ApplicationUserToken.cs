using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class ApplicationUserToken : IdentityUserToken<Guid>
    {
        public virtual ApplicationUser? User { get; set; }
    }
}
