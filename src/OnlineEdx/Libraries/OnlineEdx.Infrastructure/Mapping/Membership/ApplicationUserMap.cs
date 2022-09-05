﻿using FluentNHibernate.AspNetCore.Identity.Mappings;
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
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            HasMany(x => x.Enrolls)
                .Cascade.All()
                .Fetch.Join()
                .Inverse().KeyColumn("ApplicationUserId");
        }
    }
}
