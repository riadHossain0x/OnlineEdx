using OnlineEdx.Infrastructure.Entities.Membership;
using OnlineEdx.Infrastructure.UnitOfWorks;

namespace OnlineEdx.Membership.Services
{
    public interface IUserRoleManager
    {
        IList<string> GetRolesAsync(ApplicationUser appUser);
    }

    public class UserRoleManager : IUserRoleManager
    {
        private readonly IEdxUnitOfWork _edxUnitOfWork;

        public UserRoleManager(IEdxUnitOfWork edxUnitOfWork)
        {
            _edxUnitOfWork = edxUnitOfWork;
        }

        public IList<string> GetRolesAsync(ApplicationUser appUser)
        {
            var roles = _edxUnitOfWork.RoleManagerRepository.Find(x => x.ApplicationUser.Id == appUser.Id)
                .Select(x => x.Role.Name).ToList();

            return roles;
        }
    }
}
