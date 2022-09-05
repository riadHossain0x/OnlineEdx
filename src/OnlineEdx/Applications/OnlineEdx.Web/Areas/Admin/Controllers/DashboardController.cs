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

        public async Task<IActionResult> Index(Guid id)
        {
            var model = _scope.Resolve<DashboardModel>();
            var datatableModel = new DataTablesAjaxRequestModel(Request);
            await model.GetEnrolledUsers(datatableModel);
            return View(model);
        }
    }
}
