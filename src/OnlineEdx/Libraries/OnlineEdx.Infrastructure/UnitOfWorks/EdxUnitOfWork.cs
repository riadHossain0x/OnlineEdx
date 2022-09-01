using OnlineEdx.Data;
using OnlineEdx.Infrastructure.Repositories;

namespace OnlineEdx.Infrastructure.UnitOfWorks
{
    public class EdxUnitOfWork : UnitOfWork, IEdxUnitOfWork
    {
        public EdxUnitOfWork(IDataSessionFactory session) : base(session)
        {
            CourseRepository = new CourseRepository(_session);
        }

        public ICourseRepository CourseRepository { get; }
    }
}
