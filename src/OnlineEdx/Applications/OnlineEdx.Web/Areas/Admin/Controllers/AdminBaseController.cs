using Autofac;
using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Web.Controllers;

namespace OnlineEdx.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBaseController<T> : BaseController<T> where T : Controller
    {
        public AdminBaseController(ILogger<T> logger, ILifetimeScope scope) : base(logger, scope)
        {
        }

    }
}
