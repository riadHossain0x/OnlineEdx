using NHIdentityRole = NHibernate.AspNetCore.Identity.IdentityRole;

namespace OnlineEdx.Infrastructure.Entities.Membership
{
    public class Role : NHIdentityRole
    {
        public Role()
           : base()
        {
        }
    }
}
