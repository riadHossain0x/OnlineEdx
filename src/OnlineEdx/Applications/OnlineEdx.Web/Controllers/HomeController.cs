using Microsoft.AspNetCore.Mvc;
using NHibernate;
using OnlineEdx.Infrastructure.Entities;
using OnlineEdx.Infrastructure.Services;
using OnlineEdx.Infrastructure.SessionFactories;
using OnlineEdx.Web.Models;
using System.Diagnostics;

namespace OnlineEdx.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CourseService _courseService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            var context = new MsSQLSessionFactory();
            _courseService = new CourseService(context);
        }

        public IActionResult Index()
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                Title = "Asp.Net Core",
                Description = "Beginner friendly course",
                Image = "Default.jpg",
                PreviewVideo = "http://youtube.com/videos"
            };
            _courseService.Add(course);
            return View();
        }

        public IActionResult Privacy()
        {
            var courses = _courseService.GetAll();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}