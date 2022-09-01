using OnlineEdx.Data;
using OnlineEdx.Infrastructure.Repositories;

namespace OnlineEdx.Infrastructure.UnitOfWorks
{
    public class EdxUnitOfWork : UnitOfWork, IEdxUnitOfWork
    {
        public ICourseRepository CourseRepository { get; set; }
        public EdxUnitOfWork(IDataSessionFactory session,
            ICourseRepository courseRepository) : base(session)
        {
            CourseRepository = courseRepository;
        }
    }
}
