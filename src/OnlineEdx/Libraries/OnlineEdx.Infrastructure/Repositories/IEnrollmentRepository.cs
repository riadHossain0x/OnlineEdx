using OnlineEdx.Data;
using OnlineEdx.Infrastructure.Entities;

namespace OnlineEdx.Infrastructure.Repositories
{
    public interface IEnrollmentRepository : IRepository<Enroll, int>
    {
    }
}
