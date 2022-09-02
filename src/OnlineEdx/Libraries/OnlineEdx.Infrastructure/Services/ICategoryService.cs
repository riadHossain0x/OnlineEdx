using OnlineEdx.Infrastructure.Entities;
using OnlineEdx.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.Services
{
    public interface ICategoryService
    {
        Category Get(int id);
        IQueryable<Category> GetAll();
        IQueryable<Category> Find(Expression<Func<Category, bool>> predicate);
        void Add(Category category);
        void AddRange(IEnumerable<Category> entities);
        void Update(Category entity);
        void Remove(Category entity);
        void RemoveRange(IEnumerable<Category> entities);
    }
    public class CategoryService : ICategoryService
    {
        private readonly IEdxUnitOfWork _edxUnitOfWork;

        public CategoryService(IEdxUnitOfWork unitOfWork)
        {
            _edxUnitOfWork = unitOfWork;
        }
        public void Add(Category category)
        {
            _edxUnitOfWork.CategoryRepository.Add(category);
            _edxUnitOfWork.SaveChanges();
        }

        public void AddRange(IEnumerable<Category> entities)
        {
            _edxUnitOfWork.CategoryRepository.AddRange(entities);
            _edxUnitOfWork.SaveChanges();
        }

        public IQueryable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            return _edxUnitOfWork.CategoryRepository.Find(predicate).AsQueryable();
        }

        public Category Get(int id)
        {
            return _edxUnitOfWork.CategoryRepository.Get(id);
        }

        public IQueryable<Category> GetAll()
        {
            return _edxUnitOfWork.CategoryRepository.GetAll().AsQueryable();
        }

        public void Remove(Category entity)
        {
            _edxUnitOfWork.CategoryRepository.Remove(entity);
            _edxUnitOfWork.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Category> entities)
        {
            _edxUnitOfWork.CategoryRepository.RemoveRange(entities);
            _edxUnitOfWork.SaveChanges();
        }

        public void Update(Category entity)
        {
            _edxUnitOfWork.CategoryRepository.Update(entity);
            _edxUnitOfWork.SaveChanges();
        }
    }
}
