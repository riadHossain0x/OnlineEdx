using OnlineEdx.Infrastructure.BusinessObjects;
using System.Linq.Expressions;

namespace OnlineEdx.Infrastructure.Services
{
    public interface ICategoryService
    {
        Category GetById(Guid id);
        IQueryable<Category> GetAll();
        void Add(Category category);
        void Update(Category entity);
        void Remove(Category entity);
        Task<(int total, int totalDisplay, IList<Category> records)> GetCategorisAsync(int pageIndex, int pageSize, 
            string searchText, string orderBy);
        void RemoveById(Guid id);
    }
}
