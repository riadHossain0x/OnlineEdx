using FluentNHibernate.AspNetCore.Identity.Mappings;
using OnlineEdx.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.Mapping.Membership
{
    public class ApplicationUserMap : IdentityUserMapBase<ApplicationUser, Guid>
    {
        public ApplicationUserMap() : base(t => t.GeneratedBy.Guid()) // Primary key config
        {
            Map(t => t.FirstName).Not.Nullable();
            Map(t => t.LastName).Not.Nullable();
        }
    }
}
