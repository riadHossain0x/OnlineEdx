using Autofac;
using AutoMapper;
using OnlineEdx.Infrastructure.Services;

namespace OnlineEdx.Web.Models
{
    public class CourseDetailsModel : BaseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PreviewVideo { get; set; } = null!; 

        private readonly ICourseService _courseService = null!;

        public CourseDetailsModel()
        {

        }

        public CourseDetailsModel(IMapper mapper, ILifetimeScope scope, ICourseService courseService)
            : base(mapper, scope)
        {
            _courseService = courseService;
        }

        public void GetCourseDetails(Guid id)
        {
            var course = _courseService.GetById(id);
            _mapper.Map(course, this);
        }
    }
}
