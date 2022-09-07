using OnlineEdx.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.Seeds
{
    public static class RoleSeed
    {
        public static AppRole[] Roles
        {
            get
            {
                return new AppRole[]
                {
                    new AppRole
                    {
                        Id = Guid.Parse("23B62F00-0B27-48A3-BD63-3F1E6B298708"),
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new AppRole
                    {
                        Id = Guid.Parse("20D4EA16-82CE-4D83-9BA5-0F5C3D38EBDD"),
                        Name = "User",
                        NormalizedName = "USER"
                    }
                };
            }
        }
    }
}
