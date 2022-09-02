using NHIdentityUser = NHibernate.AspNetCore.Identity.IdentityUser;

namespace OnlineEdx.Infrastructure.Entities.Membership
{
    public class ApplicationUser : NHIdentityUser
    {
        public string Image { get; set; } = null!;
    }
}
