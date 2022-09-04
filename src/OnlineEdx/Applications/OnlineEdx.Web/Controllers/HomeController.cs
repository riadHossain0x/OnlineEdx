using Autofac;
using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Infrastructure.BusinessObjects;
using OnlineEdx.Infrastructure.Entities;
using OnlineEdx.Infrastructure.Services;
using OnlineEdx.Membership.Services;
using OnlineEdx.Web.Models;
using System.Diagnostics;

namespace OnlineEdx.Web.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public HomeController(ILogger<HomeController> logger, ILifetimeScope scope)
            : base(logger, scope)
        {
        }

        public IActionResult Index()
        {
            var model = _scope.Resolve<HomeModel>();
            try
            {
                model.LoadData();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}