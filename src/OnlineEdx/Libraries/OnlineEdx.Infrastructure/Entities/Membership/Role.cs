using FluentNHibernate.AspNetCore.Identity;

namespace OnlineEdx.Infrastructure.Entities.Membership
{
    public class Role : IdentityRole<Guid>
    {
        public virtual string RoleDescription { get; set; } = null!;
    }
}
