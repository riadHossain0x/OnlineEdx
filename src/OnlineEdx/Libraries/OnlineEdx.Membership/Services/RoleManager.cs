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
            var roles = _edxUnitOfWork.RoleManagerRepository.Find(x => x.ApplicationUser.Id == appUser.Id)
                .Select(x => x.Role.Name).ToList();

            return roles;
        }

        public void AddToRoles(ApplicationUser appUser, string[] roles)
        {
            roles.ToList().ForEach(x =>
            {
                var role = _edxUnitOfWork.RoleManagerRepository.Find(t => t.Role.Name == x)
                .Select(x => new AppRole
                {
                    Id = x.Role.Id,
                    Name = x.Role.Name,
                    NormalizedName = x.Role.Name,
                }).FirstOrDefault();

                if (role == null)
                    throw new InvalidOperationException($"{x} roll not found.");

                var userRole = new UserRole
                {
                    ApplicationUser = appUser,
                    Role = role
                };
                _edxUnitOfWork.RoleManagerRepository.Merge(userRole);
            });
        }
    }
}
