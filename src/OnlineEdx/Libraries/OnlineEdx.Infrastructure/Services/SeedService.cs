using NHibernate;
using OnlineEdx.Infrastructure.Entities.Membership;
using OnlineEdx.Infrastructure.Seeds;

namespace OnlineEdx.Infrastructure.Services
{
    public class SeedService : ISeedService
    {
        private readonly ISession _session;

        public SeedService(ISession session)
        {
            _session = session;
        }

        public void Seeds()
        {
            ApplicationUser();
            Role();

            _session.Flush();
        }

        private void ApplicationUser()
        {
            var users = ApplicationUserSeed.Users;
            foreach (var user in users)
            {
                var count = _session.Query<ApplicationUser>().Where(t => t.Email == user.Email).Count();
                if (count > 0)
                    continue;

                _session.Save(user);
            }
        }

        private void Role()
        {
            var roles = RoleSeed.Roles;
            foreach (var role in roles)
            {
                var count = _session.Query<AppRole>().Where(t => t.Name == role.Name).Count();
                if (count > 0)
                    continue;

                _session.Save(role);
            }
        }
    }
}
