using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Infrastructure.Exceptions;
using OnlineEdx.Web.Enums;
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
