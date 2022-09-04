using Autofac;
using AutoMapper;
using OnlineEdx.Infrastructure.Services;

namespace OnlineEdx.Web.Areas.Admin.Models
{
    public class DeleteCourseModel : AdminBaseModel
    {
        private readonly ICourseService _courseService;

        public DeleteCourseModel(IMapper mapper, ILifetimeScope scope, ICourseService courseService)
            : base(mapper, scope)
        {
            _courseService = courseService;
        }

        public void DeleteCourse(Guid id)
        {
            _courseService.RemoveById(id);
        }
    }
}
