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
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new AppRole
                    {
                        Name = "User",
                        NormalizedName = "USER"
                    }
                };
            }
        }
    }
}
