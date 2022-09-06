using Microsoft.AspNetCore.Identity;
using NHibernate.Util;
using OnlineEdx.Infrastructure.Entities.Membership;

namespace OnlineEdx.Infrastructure.Seeds
{
    public static class ApplicationUserSeed
    {
        public static ApplicationUser[] Users
        {
            get
            {
                var rootUser = new ApplicationUser
                {
                    Id = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    FirstName = "Admin",
                    LastName = "",
                    UserName = "admin@edx.com",
                    NormalizedUserName = "ADMIN@EDX.COM",
                    Email = "admin@devpos.com",
                    NormalizedEmail = "ADMIN@EDX.COM",
                    LockoutEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                };
                var password = new PasswordHasher<ApplicationUser>();
                var rootHashed = password.HashPassword(rootUser, "Admin.00");
                rootUser.PasswordHash = rootHashed;

                return new ApplicationUser[]
                {
                    rootUser,
                };
            }
        }
    }
}
