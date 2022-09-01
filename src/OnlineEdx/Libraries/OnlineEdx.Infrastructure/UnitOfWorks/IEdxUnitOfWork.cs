using OnlineEdx.Data;
using OnlineEdx.Infrastructure.Repositories;

namespace OnlineEdx.Infrastructure.UnitOfWorks
{
    public interface IEdxUnitOfWork : IUnitOfWork
    {
        ICourseRepository CourseRepository { get; set; }
    }
}
