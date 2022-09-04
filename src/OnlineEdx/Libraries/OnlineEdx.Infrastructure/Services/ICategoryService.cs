using OnlineEdx.Infrastructure.BusinessObjects;

namespace OnlineEdx.Infrastructure.Services
{
    public interface ICategoryService
    {
        Category GetById(Guid id);
        Category GetLazyById(Guid id);
        IList<Category> GetCategories();
        IList<Category> GetShortedCategories();
        void Add(Category category);
        void Update(Category entity);
        Task<(int total, int totalDisplay, IList<Category> records)> GetCategorisAsync(int pageIndex, int pageSize, 
            string searchText, string orderBy);
        void RemoveById(Guid id);
    }
}
