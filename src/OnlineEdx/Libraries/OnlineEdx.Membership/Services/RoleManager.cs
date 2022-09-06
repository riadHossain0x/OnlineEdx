using OnlineEdx.Infrastructure.Entities.Membership;
using OnlineEdx.Infrastructure.UnitOfWorks;

namespace OnlineEdx.Membership.Services
{
    public interface IUserRoleManager
    {
        IList<string> GetRoles(ApplicationUser appUser);
    }

    public class UserRoleManager : IUserRoleManager
    {
        private readonly IEdxUnitOfWork _edxUnitOfWork;

        public UserRoleManager(IEdxUnitOfWork edxUnitOfWork)
        {
            _edxUnitOfWork = edxUnitOfWork;
        }

        public IList<string> GetRoles(ApplicationUser appUser)
        {
            var roles = _edxUnitOfWork.RoleManagerRepository.Find(x => x.ApplicationUser.Id == appUser.Id)
                .Select(x => x.Role.Name).ToList();

            return roles;
        }

        public void AddToRoles(ApplicationUser appUser, string[] roles)
        {
            roles.ToList().ForEach(x =>
            {
                var userRole = new UserRole
                {
                    ApplicationUser = appUser,
                    Role = new AppRole
                    {
                        Name = x,
                        NormalizedName = x.ToUpper()
                    }
                };
                _edxUnitOfWork.RoleManagerRepository.Add(userRole);
            });
        }
    }
}
