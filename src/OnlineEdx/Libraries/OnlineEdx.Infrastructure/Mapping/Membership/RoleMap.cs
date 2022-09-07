using FluentNHibernate.Mapping;
using OnlineEdx.Infrastructure.Entities.Membership;

namespace OnlineEdx.Infrastructure.Mapping.Membership
{
    public class RoleMap : ClassMap<AppRole> 
    {
        public RoleMap()
        {
            Table("AspNetRoles");
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.NormalizedName);
        }
    }
}
