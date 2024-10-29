using Domain.Constants;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Identity.Models
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class ApplicationUser : IdentityUser, IUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; } = string.Empty;
        public DateTime? LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<ApplicationUserClaim> Claims { get; set; } = [];
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; } = [];
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; } = [];
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = [];
    }
}
