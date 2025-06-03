using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
        public virtual ApplicationUser? User { get; set; }
    }
}
