using FluentNHibernate.Mapping;
using OnlineEdx.Infrastructure.Entities.Membership;

namespace OnlineEdx.Infrastructure.Mapping.Membership
{
    public class UserRoleMap : ClassMap<UserRole>
    {
        public UserRoleMap()
        {
            Table("AspNetUserRoles");
            Id(x => x.Id).GeneratedBy.Identity();
            References(x => x.ApplicationUser)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("UserId");
            References(x => x.Role)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("RoleId");
        }
    }
}
