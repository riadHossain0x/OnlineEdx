using AutoMapper;
using OnlineEdx.Infrastructure.BusinessObjects;
using OnlineEdx.Infrastructure.Entities;
using OnlineEdx.Infrastructure.UnitOfWorks;
using System.Linq.Expressions;
using CategoryBO = OnlineEdx.Infrastructure.BusinessObjects.Category;
using CategoryEO = OnlineEdx.Infrastructure.Entities.Category;

namespace OnlineEdx.Infrastructure.Services
{
	public class CategoryService : ICategoryService
    {
        private readonly IEdxUnitOfWork _edxUnitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IEdxUnitOfWork unitOfWork, IMapper mapper)
        {
            _edxUnitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(CategoryBO category)
        {
            var count = _edxUnitOfWork.CategoryRepository.Find(x => x.Name.ToLower() == category.Name.ToLower()).Count();

            if (count > 0)
                throw new InvalidOperationException("Category already exists!");

            var categoryEO = _mapper.Map<CategoryEO>(category);
            _edxUnitOfWork.CategoryRepository.Add(categoryEO);
            _edxUnitOfWork.SaveChanges();
        }

        public CategoryBO GetById(Guid id)
        {
            var count = _edxUnitOfWork.CategoryRepository.Find(x => x.Id == id).Count();

            if (count == 0)
                throw new InvalidOperationException("Category not found, please try again.");

            var categoryEO = _edxUnitOfWork.CategoryRepository.Get(id);
            return _mapper.Map<CategoryBO>(categoryEO);
        }

        public IQueryable<CategoryBO> GetAll()
        {
            var categoriesEO = _edxUnitOfWork.CategoryRepository.GetAll().AsQueryable();
            return _mapper.Map<IQueryable<CategoryBO>>(categoriesEO);
        }

        public async Task<(int total, int totalDisplay, IList<CategoryBO> records)> GetCategorisAsync(int pageIndex, 
            int pageSize, string searchText, string orderBy)
        {
            var result = await _edxUnitOfWork.CategoryRepository.GetDynamicAsync(x => x.Name.Contains(searchText), orderBy, pageIndex, pageSize);

            var categories = result.data.Select(x => _mapper.Map<CategoryBO>(x)).ToList();
            return (result.total, result.totalDisplay, categories);
        }

        public void Remove(CategoryBO entity)
        {
            var categoryEO = _mapper.Map<CategoryEO>(entity);
            _edxUnitOfWork.CategoryRepository.Remove(categoryEO);
            _edxUnitOfWork.SaveChanges();
        }

        public void RemoveById(Guid id)
        {
            var count = _edxUnitOfWork.CategoryRepository.Find(x => x.Id == id).Count();

            if (count == 0)
                throw new InvalidOperationException("Category not found, please try again.");

            var categoryEO = _edxUnitOfWork.CategoryRepository.Get(id);
            _edxUnitOfWork.CategoryRepository.Remove(categoryEO);
            _edxUnitOfWork.SaveChanges();
        }

        public void Update(CategoryBO entity)
        {
            var categoryEO = _mapper.Map<CategoryEO>(entity);
            _edxUnitOfWork.CategoryRepository.Update(categoryEO);
            _edxUnitOfWork.SaveChanges();
        }
    }
}
