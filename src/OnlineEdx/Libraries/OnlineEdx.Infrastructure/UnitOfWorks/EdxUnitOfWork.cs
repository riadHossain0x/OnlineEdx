using OnlineEdx.Data;

namespace OnlineEdx.Infrastructure.UnitOfWorks
{
    public class EdxUnitOfWork : UnitOfWork, IEdxUnitOfWork
    {
        public EdxUnitOfWork(IDataSessionFactory session) : base(session)
        {
        }
    }
}
