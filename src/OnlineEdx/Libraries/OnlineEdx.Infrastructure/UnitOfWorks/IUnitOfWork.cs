using OnlineEdx.Infrastructure.Repositories;

namespace OnlineEdx.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository CourseRepository { get; }
        void SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
    }
}