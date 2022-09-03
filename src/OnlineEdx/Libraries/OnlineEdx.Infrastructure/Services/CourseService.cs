using OnlineEdx.Infrastructure.Entities;
using OnlineEdx.Infrastructure.UnitOfWorks;
using System.Linq.Expressions;

namespace OnlineEdx.Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly IEdxUnitOfWork _edxUnitOfWork;

        public CourseService(IEdxUnitOfWork unitOfWork)
        {
            _edxUnitOfWork = unitOfWork;
        }
        public void Add(Course course)
        {
            _edxUnitOfWork.CourseRepository.Add(course);
            _edxUnitOfWork.SaveChanges();
        }

        public IQueryable<Course> Find(Expression<Func<Course, bool>> predicate)
        {
            return _edxUnitOfWork.CourseRepository.Find(predicate).AsQueryable();
        }

        public Course Get(Guid id)
        {
            return _edxUnitOfWork.CourseRepository.Get(id);
        }

        public IQueryable<Course> GetAll()
        {
            return _edxUnitOfWork.CourseRepository.GetAll().AsQueryable();
        }

        public void Remove(Course entity)
        {
            _edxUnitOfWork.CourseRepository.Remove(entity);
            _edxUnitOfWork.SaveChanges();
        }

        public void Update(Course entity)
        {
            _edxUnitOfWork.CourseRepository.Update(entity);
            _edxUnitOfWork.SaveChanges();
        }
    }
}
