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

        private readonly ICourseService _courseService;

        public GetCoursesHomeModel(IMapper mapper, ILifetimeScope scope, ICourseService courseService)
            : base(mapper, scope)
        {
            _courseService = courseService;
        }

        internal async Task<(int total, int filtered, IList<Course> records)> GetFilteredCourses()
        {
            var data = await _courseService.GetCoursesAsync(
                CategoryName,
                PageIndex,
                10,
                "Title");
            var model = new List<Course>();
            foreach (var course in data.records)
            {
                model.Add(course);
            }
            return (data.total, data.totalDisplay, model);
        }
    }
}
