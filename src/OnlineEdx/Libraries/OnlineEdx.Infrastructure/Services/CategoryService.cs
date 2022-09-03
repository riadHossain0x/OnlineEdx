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
            var categoryEO = _mapper.Map<CategoryEO>(category);
            _edxUnitOfWork.CategoryRepository.Add(categoryEO);
            _edxUnitOfWork.SaveChanges();
        }

        public void AddRange(IEnumerable<CategoryBO> entities)
        {
            var categoriesEO = _mapper.Map<List<CategoryEO>>(entities);
            _edxUnitOfWork.CategoryRepository.AddRange(categoriesEO);
            _edxUnitOfWork.SaveChanges();
        }

        //public IQueryable<CategoryBO> Find(Expression<Func<CategoryBO, bool>> predicate)
        //{
        //    return _edxUnitOfWork.CategoryRepository.Find(predicate).AsQueryable();
        //}

        public CategoryBO Get(int id)
        {
            var categoryEO = _edxUnitOfWork.CategoryRepository.Get(id);
            return _mapper.Map<CategoryBO>(categoryEO);
        }

        public IQueryable<CategoryBO> GetAll()
        {
            var categoriesEO = _edxUnitOfWork.CategoryRepository.GetAll().AsQueryable();
            return _mapper.Map<IQueryable<CategoryBO>>(categoriesEO);
        }

        public void Remove(CategoryBO entity)
        {
            var categoryEO = _mapper.Map<CategoryEO>(entity);
            _edxUnitOfWork.CategoryRepository.Remove(categoryEO);
            _edxUnitOfWork.SaveChanges();
        }

        public void RemoveRange(IEnumerable<CategoryBO> entities)
        {
            var entitiesEO = _mapper.Map<List<CategoryEO>>(entities);
            _edxUnitOfWork.CategoryRepository.RemoveRange(entitiesEO);
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
