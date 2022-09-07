using NHibernate;
using OnlineEdx.Data;
using OnlineEdx.Infrastructure.Entities.Membership;

namespace OnlineEdx.Infrastructure.Repositories
{
    public interface IUserRoleRepository : IRepository<UserRole, int>
    {
    }
    public class UserRoleRepository : Repository<UserRole, int>, IUserRoleRepository
    {
        public UserRoleRepository(ISession session) : base(session)
        {
        }
    }

    public interface IRoleRepository : IRepository<AppRole, Guid>
    {

    }
    public class RoleRepository : Repository<AppRole, Guid>, IRoleRepository
    {
        public RoleRepository(ISession session) : base(session)
        {
        }
    }
}
