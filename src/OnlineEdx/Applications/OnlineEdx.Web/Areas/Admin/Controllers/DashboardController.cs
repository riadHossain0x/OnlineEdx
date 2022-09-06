using Autofac;
using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Web.Areas.Admin.Models;
using OnlineEdx.Web.Models;

namespace OnlineEdx.Web.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController<DashboardController>
    {
        public DashboardController(ILogger<DashboardController> logger, ILifetimeScope scope) 
            : base(logger, scope)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetEnrollmentDetails()
        {
            try
            {

                var model = _scope.Resolve<DashboardModel>();
                var datatableModel = new DataTablesAjaxRequestModel(Request);
                var list = await model.GetEnrolledUsers(datatableModel);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
    }
}
