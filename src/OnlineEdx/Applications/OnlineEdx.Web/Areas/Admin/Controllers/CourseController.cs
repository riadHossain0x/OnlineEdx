using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace OnlineEdx.Web.Areas.Admin.Controllers
{
	public class CourseController : AdminBaseController<CourseController>
	{
		public CourseController(ILogger<CourseController> logger, ILifetimeScope scope) : base(logger, scope)
		{
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
