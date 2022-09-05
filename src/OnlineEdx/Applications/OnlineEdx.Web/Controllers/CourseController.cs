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

        [Route("[controller]/all/{name?}/{pn?}")]
        public async Task<IActionResult> Index(string name, int pn)
        {
            var model = _scope.Resolve<GetCoursesHomeModel>();
            model.CategoryName = name;
            model.PageIndex = (pn == 0) ? 1 : pn;

            await model.GetFilteredCourses();
            model.PaginationRaw = PagingModel.SetPaging(model.PageIndex, 10, model.Courses.total,
                "activeLink", Url.Action("Index", "Course"), "disableLink");

            return View(model);
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
