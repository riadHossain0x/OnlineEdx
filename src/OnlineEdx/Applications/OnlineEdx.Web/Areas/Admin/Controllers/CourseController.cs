using Autofac;
using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Web.Areas.Admin.Models;
using OnlineEdx.Web.Enums;
using OnlineEdx.Web.Models;

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
        public async Task<JsonResult> GetCourses()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<GetCoursesModel>();
            var list = await model.GetCoursesAsync(dataTableModel);
            return Json(list);
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

		[HttpGet]
		public IActionResult Edit(Guid id)
		{
			var model = _scope.Resolve<EditCourseModel>();
			model.GetCourse(id);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditCourseModel model)
		{
			try
			{
				if (!ModelState.IsValid)
					throw new InvalidOperationException("Please provide value for all fields");

				model.ResolveDependency(_scope);
				await model.UpdateCourseAsync();

				ViewResponse("Course successfully updated.", ResponseTypes.Success);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				ViewResponse(ex.Message, ResponseTypes.Error);
			}
			model.GetCourse(model.Id);
			return View(model);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var model = _scope.Resolve<DeleteCourseModel>();
                model.DeleteCourse(id);

                ViewResponse("Category successfully deleted.", ResponseTypes.Success);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ViewResponse(ex.Message, ResponseTypes.Error);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
