using Autofac;
using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Web.Models;

namespace OnlineEdx.Web.Controllers
{
    public class EnrollController : BaseController<EnrollController>
    {
        public EnrollController(ILogger<EnrollController> logger, ILifetimeScope scope) : base(logger, scope)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> EnrollCourse(Guid id)
        {
            var model = _scope.Resolve<EnrollCourseModel>();
            await model.EnrollAsync(id);
            return null!;
        }
    }
}
