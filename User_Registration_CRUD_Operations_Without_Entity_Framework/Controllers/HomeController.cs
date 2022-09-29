﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using User_Registration_CRUD_Operations_Without_Entity_Framework.Models;

namespace User_Registration_CRUD_Operations_Without_Entity_Framework.Controllers
{
    /*If you dont want it remove it together with it's views and models*/
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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