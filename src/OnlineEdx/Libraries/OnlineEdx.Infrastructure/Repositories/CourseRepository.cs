using NHibernate;
using OnlineEdx.Data;
using OnlineEdx.Infrastructure.Entities;

namespace OnlineEdx.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course, Guid>, ICourseRepository
    {
        public CourseRepository(ISession session) : base(session)
        {
        }
    }
}
