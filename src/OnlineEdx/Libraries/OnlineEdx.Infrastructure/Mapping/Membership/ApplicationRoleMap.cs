using FluentNHibernate.AspNetCore.Identity.Mappings;
using OnlineEdx.Infrastructure.Entities.Membership;

namespace OnlineEdx.Infrastructure.Mapping.Membership
{
    public class ApplicationRoleMap : IdentityRoleMapBase<Role, Guid>
    {
        public ApplicationRoleMap() : base(t => t.GeneratedBy.Guid())
        {
            Map(t => t.RoleDescription).Length(100).Nullable();
        }
    }
}
