using Autofac;
using AutoMapper;
using OnlineEdx.Infrastructure.Services;
using OnlineEdx.Membership.Services;

namespace OnlineEdx.Web.Models
{
    public class EnrollCourseModel : BaseModel
    {
        private readonly IAccountService _accountService = null!;
        private readonly ICourseService _courseService = null!;

        public EnrollCourseModel()
        {

        }

        public EnrollCourseModel(IMapper mapper, ILifetimeScope scope, 
            IAccountService accountService, ICourseService courseService )
            : base(mapper, scope)
        {
            _accountService = accountService;
            _courseService = courseService;
        }

        public async Task EnrollAsync(Guid courseId)
        {
            var course = _courseService.GetById(courseId);
            var appUser = await _accountService.GetUserAsync();
        }
    }
}
