using Autofac;
using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Web.Areas.Admin.Models;
using OnlineEdx.Web.Enums;
using OnlineEdx.Web.Models;

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
            return View();
        }

        public async Task<JsonResult> GetCategories()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<GetCategoriesModel>();
            var list = await model.GetCategoriesAsync(dataTableModel);
            return Json(list);
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

        public IActionResult Delete(Guid id)
        {
            try
            {
                var model = _scope.Resolve<DeleteCategoryModel>();
                model.DeleteCategory(id);

                ViewResponse("Category successfully deleted.", ResponseTypes.Success);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ViewResponse(ex.Message, ResponseTypes.Error);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
