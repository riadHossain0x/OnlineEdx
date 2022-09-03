using System.Linq.Expressions;

namespace OnlineEdx.Data
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        Task<(IList<TEntity> data, int total, int totalDisplay)> GetDynamicAsync(
            Expression<Func<TEntity, bool>> filter = null!, string orderBy = null!, int pageIndex = 1, int pageSize = 10);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}