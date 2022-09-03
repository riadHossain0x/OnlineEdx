using Autofac;
using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Web.Areas.Admin.Models;
using OnlineEdx.Web.Enums;

namespace OnlineEdx.Web.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController<CategoryController>
    {
        public CategoryController(ILogger<CategoryController> logger, ILifetimeScope scope)
            : base(logger, scope)
        {
        }

        public IActionResult Index()
        {
            // category list
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidOperationException("Please provide value for all field.");

                model.ResolveDependency(_scope);
                await model.CreateCategory();
                ViewResponse("Category successfully created.", ResponseTypes.Success);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewResponse(ex.Message, ResponseTypes.Error);
                _logger.LogError(ex, ex.Message);
            }
            return View(model);
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
