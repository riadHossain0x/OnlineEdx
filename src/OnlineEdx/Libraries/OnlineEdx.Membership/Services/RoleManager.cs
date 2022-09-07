using OnlineEdx.Infrastructure.Entities.Membership;
using OnlineEdx.Infrastructure.UnitOfWorks;

namespace OnlineEdx.Membership.Services
{
    public interface IUserRoleManager
    {
        IList<string> GetRoles(ApplicationUser appUser);
        void AddToRoles(ApplicationUser appUser, string[] roles);
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
            var roles = _edxUnitOfWork.UserRoleRepository.Find(x => x.ApplicationUser.Id == appUser.Id)
                .Select(x => x.Role.Name).ToList();

            return roles;
        }

        public void AddToRoles(ApplicationUser appUser, string[] roles)
        {
            roles.ToList().ForEach(x =>
            {
                var role = _edxUnitOfWork.RoleRepository.Find(t => t.Name == x)
                .Select(x => new AppRole
                {
                    Id = x.Id,
                    Name = x.Name,
                    NormalizedName = x.Name.ToUpper(),
                }).FirstOrDefault();

                if (role == null)
                    return;

                var userRole = new UserRole
                {
                    ApplicationUser = appUser,
                    Role = role
                };
                _edxUnitOfWork.UserRoleRepository.Merge(userRole);
            });
        }
    }
}
