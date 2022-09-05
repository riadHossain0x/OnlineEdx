using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Web.Models;

namespace OnlineEdx.Web.Controllers
{
    [Authorize]
    public class EnrollmentController : BaseController<EnrollmentController>
    {
        public EnrollmentController(ILogger<EnrollmentController> logger, ILifetimeScope scope) : base(logger, scope)
        {
        }

        public IActionResult Index()
        { 
            var model = _scope.Resolve<EnrollCourseModel>();
            model.LoadEnrolledCourses();
            return View(model);
        }

        public async Task<JsonResult> EnrollCourse(Guid id)
        {
            try
            {
                var model = _scope.Resolve<EnrollCourseModel>();
                await model.EnrollAsync(id);
                return Json(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Json(ex.Message);
            }
        }
    }
}
