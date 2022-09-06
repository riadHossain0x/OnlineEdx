using NHibernate;
using OnlineEdx.Data;
using OnlineEdx.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.Repositories
{
    public interface IRoleManagerRepository : IRepository<UserRole, int>
    {
    }
    public class RoleManagerRepository : Repository<UserRole, int>, IRoleManagerRepository
    {
        public RoleManagerRepository(ISession session) : base(session)
        {
        }
    }
}
