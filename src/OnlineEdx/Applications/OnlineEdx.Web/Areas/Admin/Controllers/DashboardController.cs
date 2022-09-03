using Autofac;
using Microsoft.AspNetCore.Mvc;

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
    }
}
