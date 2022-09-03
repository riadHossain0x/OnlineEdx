using FluentNHibernate.AspNetCore.Identity;

namespace OnlineEdx.Infrastructure.Entities.Membership
{
    public class Role : IdentityRole<Guid>
    {
        public Role()
           : base()
        {
        }

        public Role(string roleName)
            : base(roleName)
        {
        }
    }
}
