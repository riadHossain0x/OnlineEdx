namespace OnlineEdx.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
    }
}