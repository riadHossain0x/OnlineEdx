using Autofac;
using AutoMapper;
using OnlineEdx.Infrastructure.BusinessObjects;
using OnlineEdx.Infrastructure.Services;
using OnlineEdx.Membership.Services;

namespace OnlineEdx.Web.Models
{
    public class EnrollCourseModel : BaseModel
    {
        public List<Course> Courses { get; set; } = null!;

        private readonly IEnrollmentService _enrollmentService = null!;
        private readonly IAccountService _accountService = null!;

        public EnrollCourseModel()
        {

        }

        public EnrollCourseModel(IMapper mapper, ILifetimeScope scope, IEnrollmentService enrollmentService,
            IAccountService accountService)
            : base(mapper, scope)
        {
            _enrollmentService = enrollmentService;
            _accountService = accountService;
        }

        public async Task EnrollAsync(Guid courseId)
        {
            var appUser = await _accountService.GetUserAsync();
            _enrollmentService.EnrollCourseAsync(courseId, appUser);
        }

        public void LoadEnrolledCourses()
        {
            var userId = Guid.Parse(_accountService.GetUserId());
            Courses = _enrollmentService.GetEnrolledCourses(userId).ToList();
        }
    }
}
