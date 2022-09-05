using Autofac;
using AutoMapper;
using OnlineEdx.Infrastructure.BusinessObjects;
using OnlineEdx.Infrastructure.Services;

namespace OnlineEdx.Web.Models
{
    public class GetCoursesHomeModel : BaseModel
    {
        public string CategoryName { get; set; } = null!;
        public int PageIndex { get; set; }
        public (int total, int filtered, IList<Course> records) Courses { get; set; }

        public string PaginationRaw { get; set; } = null!;

        private readonly ICourseService _courseService;

        public GetCoursesHomeModel(IMapper mapper, ILifetimeScope scope, ICourseService courseService)
            : base(mapper, scope)
        {
            _courseService = courseService;
        }

        internal async Task GetFilteredCourses()
        {
            var result = await _courseService.GetCoursesAsync(CategoryName, PageIndex, 1);

            var model = new List<Course>();
            foreach (var course in result.records)
            {
                model.Add(course);
            }

            Courses = (result.total, result.totalDisplay, model);
            //return (result.total, result.totalDisplay, model);
        }
    }
}
