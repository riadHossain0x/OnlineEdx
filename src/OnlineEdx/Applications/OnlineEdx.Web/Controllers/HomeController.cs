using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Membership.Services;
using OnlineEdx.Web.Models;
using System.Diagnostics;

namespace OnlineEdx.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;

        public HomeController(ILogger<HomeController> logger,
            IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            _accountService.CreateUserAsync(new Infrastructure.BusinessObjects.ApplicationUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Riad",
                LastName = "Hossain",
                UserName = "riad0000@gmail.com",
                Email = "riad0000@gmail.com",
                Password = "Riad.00"
            });
            return View();
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