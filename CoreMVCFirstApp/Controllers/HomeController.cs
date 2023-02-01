using CoreMVCFirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace CoreMVCFirstApp.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        public ViewResult Index()
        {
            Title = "Home Page";
            return View(); 
        }
        public ViewResult AboutUs()
        {
            Title = "About US";
            return View();
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}