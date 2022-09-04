using Autofac;
using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Web.Enums;
using OnlineEdx.Web.Models;

namespace OnlineEdx.Web.Controllers
{
    public class CourseController : BaseController<CourseController>
    {
        public CourseController(ILogger<CourseController> logger, ILifetimeScope scope) 
            : base(logger, scope)
        {
        }

        [Route("[controller]/all/{id?}")]
        public IActionResult Index(string id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var model = _scope.Resolve<CourseDetailsModel>();
            try
            {
                model.GetCourseDetails(id);
                return View(model);
            }
            catch (Exception ex)
            {
                ViewResponse(ex.Message, ResponseTypes.Error);
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
