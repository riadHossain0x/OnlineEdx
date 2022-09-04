using Autofac;
using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Web.Areas.Admin.Models;
using OnlineEdx.Web.Enums;

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
			var model = _scope.Resolve<CreateCourseModel>();
			model.GetCategoris();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCourseModel model)
        {
			try
			{
				if (!ModelState.IsValid)
					throw new InvalidOperationException("Please provide value for all fields");

				model.ResolveDependency(_scope);
				await model.CreateCourse();

                ViewResponse("Course successfully created.", ResponseTypes.Success);
				return RedirectToAction(nameof(Index));
            }
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);

				ViewResponse(ex.Message, ResponseTypes.Error);
			}

			model.GetCategoris();

            return View(model);
        }
    }
}
