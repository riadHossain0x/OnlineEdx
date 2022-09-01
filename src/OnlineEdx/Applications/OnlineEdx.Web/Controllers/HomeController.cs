using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Infrastructure.Entities;
using OnlineEdx.Infrastructure.Services;
using OnlineEdx.Web.Models;
using System.Diagnostics;

namespace OnlineEdx.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService _courseService;

        public HomeController(ILogger<HomeController> logger, 
            ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var course = new Course
            {
                Id = 1,
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