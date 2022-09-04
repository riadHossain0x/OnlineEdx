using FluentNHibernate.AspNetCore.Identity.Mappings;
using OnlineEdx.Infrastructure.Entities.Membership;

namespace OnlineEdx.Infrastructure.Mapping.Membership
{
    public class ApplicationUserRoleMap : IdentityUserRoleMapBase<UserRole, Guid>
    {
        public ApplicationUserRoleMap() : base(t => t.KeyProperty(x => x.UserId).KeyProperty(x => x.RoleId))
        {
        }
    }
}
