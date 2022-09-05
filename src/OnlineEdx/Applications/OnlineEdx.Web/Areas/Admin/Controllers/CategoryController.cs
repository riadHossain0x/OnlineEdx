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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetCategories()
        {
            try
            {
                var dataTableModel = new DataTablesAjaxRequestModel(Request);
                var model = _scope.Resolve<GetCategoriesModel>();
                var list = await model.GetCategoriesAsync(dataTableModel);
                return Json(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return null!;
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
                    throw new InvalidOperationException("Please provide value for all fields.");

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

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentNullException("Id must be provided.");

                var model = _scope.Resolve<EditCategoryModel>();
                model.GetCategory(id);

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ViewResponse(ex.Message, ResponseTypes.Error);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCategoryModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidOperationException("Please provide value for all fields.");

                model.ResolveDependency(_scope);
                await model.UpdateCategoryAsync();

                ViewResponse("Category successfully updated.", ResponseTypes.Success);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ViewResponse(ex.Message, ResponseTypes.Error);
                return View(model);
            }
        }
    }
}
