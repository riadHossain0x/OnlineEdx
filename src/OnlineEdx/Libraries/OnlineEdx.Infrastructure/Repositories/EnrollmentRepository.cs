using NHibernate;
using OnlineEdx.Data;
using OnlineEdx.Infrastructure.BusinessObjects;

namespace OnlineEdx.Infrastructure.Repositories
{
    public class EnrollmentRepository : Repository<Enroll, int>, IEnrollmentRepository
    {
        public EnrollmentRepository(ISession session) : base(session)
        {
        }
    }
}
