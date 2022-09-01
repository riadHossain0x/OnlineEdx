using Microsoft.AspNetCore.Identity;
using FluentNHibernate.Mapping;

namespace OnlineEdx.Membership.Services
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; } = null!;
        public virtual string PasswordHash { get; set; } = null!;

        public class Map : ClassMap<User>
        {
            public Map()
            {
                Id(x => x.Id).GeneratedBy.Identity();
                Map(x => x.UserName).Not.Nullable();
                Map(x => x.PasswordHash).Not.Nullable();
            }
        }
    }
}
