using OnlineEdx.Data;
using OnlineEdx.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.UnitOfWorks
{
    public interface IEdxUnitOfWork : IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IEnrollmentRepository EnrollmentRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IRoleRepository RoleRepository { get; }
    }
}
