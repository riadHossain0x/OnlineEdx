using OnlineEdx.Infrastructure.BusinessObjects;
using System.Linq.Expressions;

namespace OnlineEdx.Infrastructure.Services
{
    public interface ICategoryService
    {
        Category Get(int id);
        IQueryable<Category> GetAll();
        void Add(Category category);
        void Update(Category entity);
        void Remove(Category entity);
    }
}
