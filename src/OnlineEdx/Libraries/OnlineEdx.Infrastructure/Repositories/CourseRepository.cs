using NHibernate;
using OnlineEdx.Data;
using OnlineEdx.Infrastructure.Entities;

namespace OnlineEdx.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course, int>, ICourseRepository
    {
        public CourseRepository(IDataSessionFactory session) : base(session)
        {
        }
    }
}
