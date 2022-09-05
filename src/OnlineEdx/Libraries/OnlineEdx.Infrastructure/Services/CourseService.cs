using OnlineEdx.Infrastructure.BusinessObjects;
using CourseEO = OnlineEdx.Infrastructure.Entities.Course;
using CategoryEO = OnlineEdx.Infrastructure.Entities.Category;
using OnlineEdx.Infrastructure.UnitOfWorks;
using AutoMapper;

namespace OnlineEdx.Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly IEdxUnitOfWork _edxUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CourseService(IEdxUnitOfWork unitOfWork, IMapper mapper, ICategoryService categoryService)
        {
            _edxUnitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryService = categoryService;
        }
        public void Add(Course course)
        {
            var count = _edxUnitOfWork.CourseRepository.Find(x => x.Title.ToLower() == course.Title.ToLower()).Count();

            if (count > 0)
                throw new InvalidOperationException("Course with same name already exists!");

            var courseEO = _mapper.Map<CourseEO>(course);

            courseEO.Category = _mapper.Map<CategoryEO>(_categoryService.GetLazyById(courseEO.CategoryId));

            _edxUnitOfWork.CourseRepository.Add(courseEO);
            _edxUnitOfWork.SaveChanges();
        }

        public Course GetById(Guid id)
        {
            var count = _edxUnitOfWork.CourseRepository.Find(x => x.Id == id).Count();

            if (count == 0)
                throw new InvalidOperationException("Course not found, please try again.");

            var courseEO = _edxUnitOfWork.CourseRepository.Get(id);
            return _mapper.Map<Course>(courseEO);
        }

        public void RemoveById(Guid id)
        {
            var count = _edxUnitOfWork.CourseRepository.Find(x => x.Id == id).Count();

            if (count == 0)
                throw new InvalidOperationException("Course not found, please try again.");

            var courseEO = _edxUnitOfWork.CourseRepository.Get(id);

            _edxUnitOfWork.CourseRepository.Remove(courseEO);
            _edxUnitOfWork.SaveChanges();
        }

        public async Task<(int total, int totalDisplay, IList<Course> records)> GetCoursesAsync(int pageIndex,
            int pageSize, string searchText, string orderBy)
        {
            var result = await _edxUnitOfWork.CourseRepository.GetDynamicAsync(x => x.Title.Contains(searchText), orderBy, 
                pageIndex, pageSize);

            var courses = result.data.Select(x => _mapper.Map<Course>(x)).ToList();
            return (result.total, result.totalDisplay, courses);
        }

        public void Update(Course entity)
        {
            var count = _edxUnitOfWork.CourseRepository.Find(x => x.Id != entity.Id &&
                                                    x.Title.ToLower() == entity.Title.ToLower()).Count();

            if (count > 0)
                throw new InvalidOperationException("Course with same name already exists");

            var courseEO = _mapper.Map<CourseEO>(entity);
            courseEO.Category = _mapper.Map<CategoryEO>(_categoryService.GetLazyById(courseEO.CategoryId));

            _edxUnitOfWork.CourseRepository.Update(courseEO);
            _edxUnitOfWork.SaveChanges();
        }

        public async Task<(int total, int totalDisplay, IList<Course> records)> GetCoursesAsync(string categoryname, 
            int pageIndex, int pageSize)
        {
            var result = await _edxUnitOfWork.CourseRepository.GetDynamicAsync(x => (categoryname != null) ? 
            x.Category.Name == categoryname: x.Title != null, null!, pageIndex, pageSize);

            var courses = result.data.Select(x => _mapper.Map<Course>(x)).ToList();
            return (result.total, result.totalDisplay, courses);
        }
    }
}
