using NHibernate;
using OnlineEdx.Data;
using OnlineEdx.Infrastructure.Repositories;

namespace OnlineEdx.Infrastructure.UnitOfWorks
{
    public class EdxUnitOfWork : UnitOfWork, IEdxUnitOfWork
    {
        public EdxUnitOfWork(ISession session) : base(session)
        {
            CourseRepository = new CourseRepository(session);
            CategoryRepository = new CategoryRepository(session);
            EnrollmentRepository = new EnrollmentRepository(session);
            UserRoleRepository = new UserRoleRepository(session);
            RoleRepository = new RoleRepository(session);
        }

        public ICourseRepository CourseRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IEnrollmentRepository EnrollmentRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }
        public IRoleRepository RoleRepository { get; }
    }
}
