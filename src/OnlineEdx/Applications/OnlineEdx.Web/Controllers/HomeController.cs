﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Infrastructure.BusinessObjects;
using OnlineEdx.Infrastructure.Entities;
using OnlineEdx.Infrastructure.Services;
using OnlineEdx.Membership.Services;
using OnlineEdx.Web.Models;
using System.Diagnostics;

namespace OnlineEdx.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
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