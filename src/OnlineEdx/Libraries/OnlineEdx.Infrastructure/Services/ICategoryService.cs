using OnlineEdx.Infrastructure.BusinessObjects;
using System.Linq.Expressions;

namespace OnlineEdx.Infrastructure.Services
{
    public interface ICategoryService
    {
        Category Get(int id);
        IQueryable<Category> GetAll();
        //IQueryable<Category> Find(Expression<Func<Category, bool>> predicate);
        void Add(Category category);
        void AddRange(IEnumerable<Category> entities);
        void Update(Category entity);
        void Remove(Category entity);
        void RemoveRange(IEnumerable<Category> entities);
    }
}
